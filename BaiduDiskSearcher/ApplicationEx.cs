using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BaiduDiskSearcher
{
    static class ApplicationEx
    {
        public static string RemoveAngleBrackets(this string input)
        {
            if (input.Contains("<") && input.Contains(">"))
            {
                int firstStartIndex = input.IndexOf('<');
                int firstEndIndex = input.IndexOf('>');
                string result = input.Remove(firstStartIndex, firstEndIndex - firstStartIndex + 1);
                firstStartIndex = result.LastIndexOf('<');
                firstEndIndex = result.LastIndexOf('>');
                result = result.Remove(firstStartIndex, firstEndIndex - firstStartIndex + 1);
                return result;
            }
            else return input;
        }

        public static bool CheckLegalFileName(this string input)
        {
            string chars = "\\/:*?\"<>|.";
            for(int i=0;i<chars.Length;i++)
            {
                if (input.Contains(chars[i]))
                    return true;
            }
            return false;
        }
    }
}
