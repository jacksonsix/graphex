using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Extension
{
    public class Client
    {
        public static void run()
        {
            string s = "The quick brown fox jumped over the lazy dog.";
            //  Call the method as if it were an 
            //  instance method on the type. Note that the first
            //  parameter is not specified by the calling code.
            int i = s.WordCount();
            System.Console.WriteLine("Word count of s is {0}", i);
        }
    }
}
