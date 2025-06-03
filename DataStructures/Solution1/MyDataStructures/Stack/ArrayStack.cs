namespace MyDataStructures.Stack
{
    internal class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly List<T> list = new List<T>();

        public T Peek()
        {
            return list[Count - 1];
        }

        public T Pop()
        {
            if(Count == 0) return default(T);
            var temp = list[Count - 1];
            list.RemoveAt(--Count);
            return temp;
        }

        public void Push(T value)
        {
           if(value == null) throw new ArgumentNullException("value");
           list.Add(value);
           Count++;
        }
    }
}