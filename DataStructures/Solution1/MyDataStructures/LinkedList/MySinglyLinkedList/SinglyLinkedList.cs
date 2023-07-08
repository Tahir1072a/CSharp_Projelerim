using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.LinkedList.MySinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head == null ? true : false;
        public void AddFirst(T item)
        {
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(item);
            newNode.Next = Head;
            Head = newNode;
        }
        public void AddLast(T item)
        {
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(item);
            
            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            var ptr = Head;
            while(ptr.Next != null) { ptr = ptr.Next; }
            ptr.Next = newNode;
        }
        public void AddAfter(SinglyLinkedListNode<T> node ,T item)
        {
            if(isHeadNull)
            {
                AddFirst(item); return;
            }
            if (!Contains(node)) throw new ArgumentException("The reference node is not in this list");
            
            var prev = node;
            var newNode = new SinglyLinkedListNode<T>(item);
            newNode.Next = prev.Next;
            prev.Next = newNode; 
        }
        public void AddAfter(SinglyLinkedListNode<T> node, SinglyLinkedListNode<T> newNode)
        {
            if (isHeadNull)
            {
                Head = newNode; return;
            }
            if (!Contains(node)) throw new ArgumentException("The reference node is not in this list");
            if (Contains(newNode)) throw new ArgumentException("The referance you want to add already exist!");
            var prev = node;
            newNode.Next = prev.Next;
            prev.Next = newNode;
        }
        public void AddBefore(SinglyLinkedListNode<T> node, T item)
        {
            if (isHeadNull)
            {
                AddFirst(item); return;
            }
            if (!Contains(node)) throw new ArgumentException("The reference node is not in this list");

            var newNode = new SinglyLinkedListNode<T>(item);
            newNode.Next = node;
            if(Head.Equals(node)) Head = newNode;
        }
        public void AddBefore(SinglyLinkedListNode<T> node, SinglyLinkedListNode<T> newNode)
        {
            if (isHeadNull)
            {
                Head = newNode; return;
            }
            if (!Contains(node)) throw new ArgumentException("The reference node is not in this list");
            if (Contains(newNode)) throw new ArgumentException("The referance you want to add already exist!");
            newNode.Next = node;
            if (Head.Equals(node)) Head = newNode;
        }
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        public bool Contains(SinglyLinkedListNode<T> node)
        {
            var current = Head;
            while(current != null)
            {
                if(node.Equals(current)) return true;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
