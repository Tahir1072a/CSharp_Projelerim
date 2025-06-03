using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Queue
{
    public class Queue<T>
    {
        public readonly IQueue<T> _queue;
        public Queue(QueueType type = QueueType.Array)
        {
            if(type == QueueType.Array)
            {
                _queue = new QueueList<T>();
            }
            else if(type == QueueType.LinkedList)
            {
                _queue = new QueueLinkedList<T>();
            }
        }

        public int Count => _queue.Count;

        public T DeQueue()
        {
            return _queue.DeQueue();
        }

        public void EnQueue(T item)
        {
            _queue.EnQueue(item);
        }

        public T Peek()
        {
            return _queue.Peek();
        }
    }
    public enum QueueType
    {
        Array = 0,
        LinkedList = 1
    }
}
