using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{

    public class Node<K, T>
    {
        public K Key;
        public T Item;
        public Node<K, T> NextNode;
        public Node()
        {
            Key =  default(K);
            Item = default(T);
            NextNode = null;
        }
        public Node(K key, T item, Node<K, T> nextNode)
        {
            Key = key;
            Item = item;
            NextNode = nextNode;
        }
    }

    public class GenericLinkedList<K, T>
    {
        Node<K, T> m_Head;
        public GenericLinkedList()
        {
            m_Head = new Node<K, T>();
        }
        public void AddHead(K key, T item)
        {
            Node<K, T> newNode = new Node<K, T>(key, item, m_Head.NextNode);
            m_Head.NextNode = newNode;
        }
    }

}
