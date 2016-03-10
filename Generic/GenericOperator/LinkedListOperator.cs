using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{


    public class LinkedListOperator<K, T>
    {
        public Node<K, T> m_Head;
        public LinkedListOperator()
        {
            m_Head = new Node<K, T>();
        }
        public void AddHead(K key, T item)
        {
            Node<K, T> newNode = new Node<K, T>(key, item, m_Head.NextNode);
            m_Head.NextNode = newNode;
        }

        public static LinkedListOperator<K, T> operator +(LinkedListOperator<K, T> lhs,
                                                LinkedListOperator<K, T> rhs)
        {
            return concatenate(lhs, rhs);
        }
        static LinkedListOperator<K, T> concatenate(LinkedListOperator<K, T> list1,
                                           LinkedListOperator<K, T> list2)
        {
            LinkedListOperator<K, T> newList = new LinkedListOperator<K, T>();
            Node<K, T> current;
            current = list1.m_Head;
            while (current != null)
            {
                newList.AddHead(current.Key, current.Item);
                current = current.NextNode;
            }
            current = list2.m_Head;
            while (current != null)
            {
                newList.AddHead(current.Key, current.Item);
                current = current.NextNode;
            }
            return newList;
        }
        //Rest of LinkedList
    }
}
