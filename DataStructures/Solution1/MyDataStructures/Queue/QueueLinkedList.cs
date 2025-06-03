using MyDataStructures.LinkedList.MySinglyLinkedList;

namespace MyDataStructures.Queue
{
    internal class QueueLinkedList<T> : IQueue<T>
    {
        public int Count { get; private set; }
        private readonly SinglyLinkedList<T> linkedList = new SinglyLinkedList<T>();

        public T DeQueue()
        {
            Count--;
            return linkedList.RemoveFirst();
        }

        public void EnQueue(T item)
        {
            Count++;
            linkedList.AddLast(item);
        }

        public T Peek()
        {
            return linkedList.Head.Item;
        }
    }
}