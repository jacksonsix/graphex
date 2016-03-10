using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    public class BaseC<T> 
    {
    }
    // When deriving from a generic base class, you must provide a type argument instead of the base-class's generic type parameter:
    public class InheritanceFromGeneric : BaseC<int>
    {

    }

    public class BaseConstrint<T> where T : ISomeInterface
    {

    }

    // When using the subclass generic type parameters, you must repeat any constraints stipulated at the base class level at the subclass level
    public class AlsoGenericClass<T> : BaseC<T>
    {

    }

    public class Also2<T> : BaseConstrint<T> where T : ISomeInterface
    {

    }

    //Or constructor constraint:
    //public class BaseClass<T>  where T : new()
    //{   
    //   public T SomeMethod()
    //   {
    //      return new T();
    //   }
    //}
    //public class SubClass<T> : BaseClass<T> where T : new() 
    //{...}
}
