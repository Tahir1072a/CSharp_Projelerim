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
        public SinglyLinkedList()
        {
            
        }
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }
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
        private (SinglyLinkedListNode<T> prev,SinglyLinkedListNode<T> deletedNode) Contains(T item)
        {
            if (Head == null) throw new NullReferenceException("The list is empty!");
            if (item == null) throw new NullReferenceException("The referance value is empty!");
            var ptr = Head;
            SinglyLinkedListNode<T> prev = null;
            while (ptr != null)
            {
                if (item.Equals(ptr.Item))
                {
                    return (prev,ptr);
                }
                prev = ptr;
                ptr = ptr.Next;
            }
            return (prev,ptr);
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
        public T RemoveFirst()
        {
            var item = Head.Item;
            Head = Head.Next;
            return item;
        }
        public T RemoveLast()
        {
            var ptr = Head;
            while(ptr.Next.Next != null)
            {
                ptr = ptr.Next;
            }
            var value = ptr.Next.Item;
            ptr.Next = null;
            return value;
        }
        public void Remove(T item)
        {
            if (Head == null) throw new ArgumentException("The list is empty!");
            (var prevNode,var deletedNode)  = Contains(item);
            if(prevNode == null && deletedNode == Head)
            {
                Head = deletedNode.Next;
                deletedNode = null;
            }
            else if(deletedNode == null)
            {
                throw new ArgumentException("The value could not be found in the list!");
            }
            else
            {
                prevNode.Next = deletedNode.Next;
                deletedNode.Next = null;
                deletedNode = null;
            }
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
