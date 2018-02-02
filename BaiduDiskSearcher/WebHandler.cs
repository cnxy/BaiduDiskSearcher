using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BaiduDiskSearcher
{
    class WebHandler
    {
        public string Url { private set; get; }
        public WebHandler(string url)
        {
            this.Url = url;
        }

        public event EventHandler<PageEventArgs> PageShown;
        public event EventHandler<ItemEventArgs> ItemShown;

        protected void OnPageShown(PageEventArgs e)
        {
            this.PageShown?.Invoke(this, e);
        }

        protected void OnItemShown(ItemEventArgs e)
        {
            this.ItemShown?.Invoke(this, e);
        }

        public void Handle()
        {
            WebMatcher matcher = new WebMatcher(this.Url);
            matcher.GetWebContent();

            //获得总条数与页码
            string[] matchContents = matcher.Match("<div class=\"page-list\">.*?</span>", true);
            if (matchContents.Length == 0) return;
            matchContents = WebMatcher.Match(matchContents[0], "<span>.*?</span>");
            if (matchContents.Length == 0) return;
            Page page = GetPage(matchContents[0].RemoveAngleBrackets());
            OnPageShown(new PageEventArgs(page));
            bool cancel = false;
            for (int i = 0; i < page.TotalPages; i++)
            {
                if(i!= 0)
                {
                    matcher = new WebMatcher($"{this.Url}/{(i+1).ToString()}");
                    matcher.GetWebContent();
                }
                matchContents = matcher.Match("<ul class=\"list\".*?</ul>", true);
                if (matchContents.Length == 0) return;
                matchContents = WebMatcher.Match(matchContents[0], "<li>.*?</li>", true);
                foreach (string match in matchContents)
                {
                    Item item = new Item();
                    //文件名
                    string[] temp = WebMatcher.Match(match, "<a title.*?</a>");
                    if (temp.Length >= 2)
                    {
                        item.FileName = temp[0].RemoveAngleBrackets().RemoveAngleBrackets();
                        item.FileNameExt = Path.GetExtension(item.FileName).Replace(".", "");
                        item.FileName = Path.GetFileNameWithoutExtension(item.FileName);
                    }
                    //类别
                    temp = WebMatcher.Match(match, "<a class=\"tag\".*?</a>");
                    if (temp.Length > 0)
                    {
                        item.Type = temp[0].RemoveAngleBrackets();
                    }
                    //时间与大小
                    temp = WebMatcher.Match(match, "&nbsp;.*&nbsp;");
                    if (temp.Length > 0)
                    {
                        temp = temp[0].RemoveAngleBrackets().Split(new[] { "&nbsp;" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length >= 2)
                        {
                            item.Time = temp[0];
                            item.Size = temp[1];
                        }
                    }
                    //到下一个页面的链接
                    temp = WebMatcher.Match(match, "href.*?>");
                    if (temp.Length >= 3)
                    {
                        Uri uri = new Uri(this.Url);
                        string innerUrl = $"{uri.Scheme}://{uri.Host}{temp[0].Split('"')[1]}";
                        //<div class="share-info">
                        WebMatcher innerWebMatcher = new WebMatcher(innerUrl);
                        innerWebMatcher.GetWebContent();
                        temp = WebMatcher.Match(innerWebMatcher.WebContent, "<div class=\"share-info\">.*?</div>");
                        if(temp.Length > 0)
                        {
                            //上传用户
                            temp = WebMatcher.Match(temp[0], "<a.*?</a>");
                            if(temp.Length >0)
                            {
                                item.Sharer = temp[0].RemoveAngleBrackets();
                            }
                            //分享者主页
                            temp = WebMatcher.Match(temp[0], "href=\".*?\"");
                            if (temp.Length > 0)
                            {
                                temp = temp[0].Split(new[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                if(temp.Length >=2 )
                                {
                                    Uri innerUri = new Uri(innerWebMatcher.Url);
                                    WebMatcher skipWebMatcher = new WebMatcher($"{innerUri.Scheme}://{innerUri.Host}{temp[1]}");
                                    skipWebMatcher.GetWebContent();
                                    temp = WebMatcher.Match(skipWebMatcher.WebContent, "<div class=\"userinfo\".*?</div>", true);
                                    if(temp.Length >0)
                                    {
                                        temp = WebMatcher.Match(temp[0], "href=\".*?\"");
                                        if(temp.Length>0)
                                        {
                                            temp = temp[0].Split(new[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                            item.SharerSite = temp[1];
                                        }
                                    }
                                }

                            }
                        }
                        temp = WebMatcher.Match(innerWebMatcher.WebContent, "<div class=\"sep2 center\">.*?</div>", true);
                        if(temp.Length>0)
                        {
                            
                            temp = WebMatcher.Match(temp[0], "href=\".*?\"");
                            if(temp.Length >0)
                            {
                                //下载地址
                                temp = temp[0].Split(new[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                item.Site = temp[1];
                            }
                        }
                    }
                    ItemEventArgs e = new ItemEventArgs(item);
                    this.OnItemShown(e);
                    if(e.Cancel)
                    {
                        cancel = true;
                        break;
                    }
                }
                if(cancel)
                {
                    break;
                }
            }
        }

        private Page GetPage(string input)
        {
            Page page = new Page();
            string[] result =  input.Split(new[] { "&nbsp;" }, StringSplitOptions.RemoveEmptyEntries);
            if(result.Length >= 2)
            {
                string[] resultTemp = result[0].Split('/');
                if(resultTemp.Length >= 2)
                {
                    //总页数
                    if (int.TryParse(resultTemp[1].Remove(resultTemp[1].Length - 1, 1), out int totalPages))
                    {
                        page.TotalPages = totalPages;
                    }
                }
                //总数量
                string temp = result[1].Remove(0, 1);
                temp = temp.Remove(temp.Length - 1, 1);
                if(int.TryParse(temp,out int totalNumber))
                {
                    page.TotalNumber = totalNumber;
                }
            }
            return page;
        }
        
    }
    struct Page
    {
        public int TotalPages { set; get; }
        public int TotalNumber { set; get; }
    }

    class PageEventArgs:EventArgs
    {
        public Page Page { private set; get; }
        public PageEventArgs(Page page)
        {
            this.Page = page;
        }
    }

    class ItemEventArgs:EventArgs
    {
        public Item Item { private set; get; }
        public bool Cancel { set; get; }
        public ItemEventArgs(Item item)
        {
            this.Item = item;
        }
    }

}
