using System.Collections;

namespace MyDataStructures.Tree
{
    public class BSTEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        public T Current { get; private set; }

        object IEnumerator.Current => throw new NotImplementedException();
        public BSTEnumerator(T value)
        {
            Current = value;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}