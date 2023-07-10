using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.LinkedList.MyDoublyLinkedList
{
    public class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Back { get; set; }

        public T Value { get; set; }
        public DoubleLinkedListNode(T item)
        {
            Value = item;
        }
        public override string ToString() => $"{Value}";
    }
}
