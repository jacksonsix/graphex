using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    // object-based stack

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    class ObjectBasedStack
    {
        private  readonly int m_Size; 
        private int m_StackPointer = 0;
        private object[] m_Items;
       public ObjectBasedStack()
           : this(100)
       {}   
       public ObjectBasedStack(int size)
       {
          m_Size = size;
          m_Items = new object[m_Size];
       }
       public void Push(object item)
       {
          if(m_StackPointer >= m_Size) 
             throw new StackOverflowException();       
          m_Items[m_StackPointer] = item;
          m_StackPointer++;
       }
       public object Pop()
       {
          m_StackPointer--;
          if(m_StackPointer >= 0)
          {
             return m_Items[m_StackPointer];
          }
          else
          {
             m_StackPointer = 0;
             throw new InvalidOperationException("Cannot pop an empty stack");
          }
       }
    }
}
