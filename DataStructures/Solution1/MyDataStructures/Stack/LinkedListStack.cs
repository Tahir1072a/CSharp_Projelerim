using MyDataStructures.LinkedList.MySinglyLinkedList;

namespace MyDataStructures.Stack
{
    internal class LinkedListStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly SinglyLinkedList<T> linkedList = new();

        public T Peek()
        {
            return linkedList.Head.Item;
        }

        public T Pop()
        {
            Count--;
            return linkedList.RemoveFirst();
        }

        public void Push(T value)
        {
            linkedList.AddFirst(value);
            Count++;
        }
    }
}