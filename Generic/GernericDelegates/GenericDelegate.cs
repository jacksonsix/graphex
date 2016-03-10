using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic.GernericDelegates
{
    public class GenericDelegate<T>
    {
        public delegate void GDelegate(T t);

        public void somemethod(T t)
        {
            ;
        }

    }
}
