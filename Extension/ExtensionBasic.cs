using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Extension
{
    public static class ExtensionBasic
    {
        public static bool In<T>(this T source, params T[] list)
        {
          if(null==source) throw new ArgumentNullException("source");
          return list.Contains(source);
        }

        public static int WordCount(this string str)
        {
            return str.Split(new char[] {' ', '.', '?'}, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }


}
