using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.LinkedList.MySinglyLinkedList
{
    public class SinglyLinkedListNode<T>
    {
        public T Item { get; set; }
        public SinglyLinkedListNode<T>? Next { get; set; }

        public SinglyLinkedListNode(T value)
        {
            Item = value;
        }

        public override string ToString() => $"{Item}";
    }
}
