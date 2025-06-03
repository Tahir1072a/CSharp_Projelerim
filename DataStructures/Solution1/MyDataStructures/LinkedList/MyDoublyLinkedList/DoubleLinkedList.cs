using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.LinkedList.MyDoublyLinkedList
{
    public class DoubleLinkedList<T>
    {
        public DoubleLinkedListNode<T> Head { get; set; }
        public DoubleLinkedListNode<T> Tail { get; set; }

        public void AddFirst(T item)
        {
            var newNode = new DoubleLinkedListNode<T>(item);
            if (Head == null && Tail == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            newNode.Next = Head;
            Head.Back = newNode;
            Head = newNode;
        }
        public T RemoveFirst()
        {
            if(Head == null) throw new ArgumentNullException(nameof(Head));
            if(Tail == Head)
            {
                var value = Head.Value;
                Head = null;
                Tail = null;
                return value;
            }

            Head.Next.Back = null;
            Head = Head.Next;

            return Head.Value;
        }
    }
}
