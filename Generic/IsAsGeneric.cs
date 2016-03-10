using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    public class IsAsGeneric<T>
    {
        public void SomeMehtod(T t)
        {
            if (t is int)
            {
                ;
            }
            if (t is LinkedList<int>)
            {
                ;
            }

            string str = t as string;
            if (str != null)
            {
                ;
            }

            LinkedList<string> list = t as LinkedList<string>;
            if (list != null)
            {
                ;
            }
        }
    }
}
