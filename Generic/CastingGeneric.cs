using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    public interface ISomeInterface
    {
         
    }

    public class BaseClass
    {
    }

    //The compiler lets you explicitly cast generic type parameters to any other interface, but not to a class:
    //However, you can force a cast from a generic type parameter to any other type using a temporary Object variable
    public class CastingGeneric<T> where T : BaseClass,ISomeInterface
    {
        private void SomeMethod(T t)
        {
            ISomeInterface obj1 = t;
            BaseClass obj2 = t;
            object obj3 = t;
        }

        private void SomeMthod2(T t)
        {
            ISomeInterface obj1 = (ISomeInterface) t;  // good
            object temp = t;
            BaseClass obj2 = (BaseClass)temp;   
        }
    }
}
