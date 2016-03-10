using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    //  an important capability because it allows you to call the method with a different type every time, which is very handy for utility classes
    // You can define method-specific generic type parameters even if the containing class does not use generics at all:
    // this ability is for methods only
    public class GenericMethod<T>
    {
        public void MyMethod<X>(X x)
        {
            ;
        }

        public void somemethod<Y>(Y y) where Y : IComparable<Y>
        {
            ;
        }
    }
}
