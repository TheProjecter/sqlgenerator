using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.TSQL
{
    class Utility
    {
        public static string GetListAsString<T>(List<T> items,string separator)
        {
            if (items == null)
                return string.Empty;
            bool addSeparator = false;
            string ret = string.Empty;
            foreach (T item in items)
            {
                if (addSeparator)
                {
                    ret += separator;
                    ret += item.ToString();
                }
                else
                {
                    addSeparator = true;
                    ret += item.ToString();
                }
            }
            return ret;
        }
        public static string GetListAsString<T>(List<T> items,string prefix,string suffix, string separator)
        {
            if (items == null)
                return string.Empty;
            bool addSeparator = false;
            string ret = string.Empty;
            foreach (T item in items)
            {
                if (addSeparator)
                {
                    ret += separator;
                    ret += string.Format("{0}{1}{2}",prefix,item.ToString(),suffix);
                }
                else
                {
                    addSeparator = true;
                    ret += string.Format("{0}{1}{2}", prefix, item.ToString(), suffix);
                }
            }
            return ret;
        }
    }
}
