using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    //public class DerivedLinkedList<K,T> :IEnumerable<T> where K :IComparable<K>
    //{

    //}


//You can have a base class constraint, meaning, stipulating that the generic type parameter is derived from a particular base class:
//public class MyBaseClass
//{...}
//public class LinkedList<K,T> where K : MyBaseClass
//{...}
//However, at most one base class can be used in a constraint because C# does not support multiple inheritance of implementation. Obviously, the base class you constrain cannot be a sealed class or a static class, and the compiler enforces that. In addition, you cannot constrain System.Delegate or System.Array as a base class.
//You can constrain both a base class and one or more interfaces, but the base class must appear first in the derivation constraint list:
//public class LinkedList<K,T> where K : MyBaseClass, IComparable<K>
//{...}

    //public class LinkedList<K,T> where K : IComparable<K>,new()
    class CNode<K, T> where T : new()
    {
        public K Key;
        public T Item;
        public CNode<K, T> NextNode;
        public CNode()
        {
            Key = default(K);
            Item = new T();
            NextNode = null;
        }
    }


    // REFERENCE /value constrint
    //You can constrain a generic type parameter to be a value type (such as an int, a bool, and enum) or any custom structure
    // public class MyClass<T> where T : struct 
    
    //  constrain a generic type parameter to be a reference type (a class) using the class constraint:
    //public class MyClass<T> where T : class 

}
