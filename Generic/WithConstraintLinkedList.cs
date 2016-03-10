using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{

    public interface IComparable<T>
    {
        int CompareTo(T other);
        bool Equals(T other);
    }


    public class WithConstraintLinkedList<K, T> where K : IComparable
    {
        private Node<K, T> m_Head;
        public WithConstraintLinkedList()
        {
            m_Head = new Node<K, T>();
        }
        public void AddHead(K key, T item)
        {
            Node<K, T> newNode = new Node<K, T>(key, item, m_Head.NextNode);
            m_Head.NextNode = newNode;
        }
        T Find(K key)
        {
            Node<K, T> current = m_Head;
            while (current.NextNode != null)
            {
                if (current.Key.CompareTo(key) == 0)

                    break;
                else

                    current = current.NextNode;
            }
            return current.Item;
        }
        //Rest of the implementation 
    }
}
