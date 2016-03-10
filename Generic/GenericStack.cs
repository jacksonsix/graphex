using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    public class GenericStack<T>
    {
        private readonly int m_Size; 
        private int m_StackPointer = 0;
        private T[] m_Items;
        public GenericStack():this(100)
        {}
        public GenericStack(int size)
        {
            m_Size = size;
            m_Items = new T[m_Size];
        }
        public void Push(T item)
        {
            if(m_StackPointer >= m_Size) 
                throw new StackOverflowException();
            m_Items[m_StackPointer] = item;
            m_StackPointer++;
        }
        public T Pop()
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
