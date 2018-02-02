using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduDiskSearcher
{
    class Item
    {
        public string FileName { set; get; }
        public string FileNameExt { set; get; }
        public string Type { set; get; }
        public string Time { set; get; }
        public string Size { set; get; }
        public string Sharer { set; get; }
        public string Site { set; get; }

        public string SharerSite { set; get; }
    }
}
