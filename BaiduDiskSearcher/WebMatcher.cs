using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace BaiduDiskSearcher
{
    class WebMatcher
    {
        public string Url { private set; get; }
        public WebMatcher(string url)
        {
            this.Url = url;
        }

        public string WebContent { private set; get; }

        public string GetWebContent()
        {
            string webContent = string.Empty;
            try
            {
                HttpWebRequest request = WebRequest.Create(this.Url) as HttpWebRequest;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    this.WebContent = reader.ReadToEnd();
                }
                response.Close();
            }
            catch { }
            return webContent;
        }

        public string[] Match(string pattern, bool singleLineOrNot = false)
        {
            if (string.IsNullOrEmpty(this.WebContent)) return new string[0];
            return Match(this.WebContent, pattern, singleLineOrNot);
        }

        public static string[] Match(string webContent, string pattern, bool singleLineOrNot = false)
        {
            if (string.IsNullOrEmpty(webContent)) return new string[0];
            List<string> list = new List<string>();
            MatchCollection matches = Regex.Matches(webContent, pattern, singleLineOrNot?RegexOptions.Singleline:RegexOptions.None);
            foreach (Match match in matches)
            {
                list.Add(match.Value);
            }
            return list.ToArray();
        }

    }
}
