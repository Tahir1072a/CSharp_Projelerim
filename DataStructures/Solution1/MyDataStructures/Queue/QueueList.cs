namespace MyDataStructures.Queue
{
    internal class QueueList<T> : IQueue<T>
    {
        public int Count => list.Count;
        private readonly List<T> list = new();
        public T DeQueue()
        {
            var temp = list[0];
            list.RemoveAt(0);
            return temp;

        }

        public void EnQueue(T item)
        {
            list.Add(item);
        }

        public T Peek()
        {
            return list[0];
        }
    }
}