using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    public class Client
    {
        public static void run()
        {
            ObjectBasedStack stack = new ObjectBasedStack();
            stack.Push("1");
            string number = (string)stack.Pop();

            GenericStack<string> strstack = new GenericStack<string>();
            strstack.Push("34");
            string n = strstack.Pop();

            GenericLinkedList<int, string> list = new GenericLinkedList<int, string>();
            list.AddHead(123,"aaa");

            GenericLinkedList<DateTime,string> datestack = new GenericLinkedList<DateTime, string>();
            datestack.AddHead(DateTime.Now,"begin");

            GenericMethod<int> gm = new GenericMethod<int>();
            gm.MyMethod<double>(3.4);

            int num = GeneriStaticMethod<int>.somemethod(4);
            Console.WriteLine(num);

        }
    }
}
