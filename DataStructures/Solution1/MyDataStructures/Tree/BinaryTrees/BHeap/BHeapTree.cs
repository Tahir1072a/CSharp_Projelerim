using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Tree.BinaryTrees.BHeap
{
    public abstract class BHeapTree<T> : IEnumerable<T> where T : IComparable
    {
        protected int position;
        public T[] Array { get; private set; }
        public int Count { get; private set; }

        public BHeapTree(int size = 128)
        {
            Count = 0;
            position = 0;
            Array = new T[size];
        }
        public BHeapTree(IEnumerable<T> collection) : this(collection.Count())
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }
        protected int GetLeftChildIndex(int i) => 2 * i + 1;
        protected int GetRightChildIndex(int i) => 2 * i + 2;
        protected int GetParentIndex(int i) => (i - 1) / 2;
        protected bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        protected bool HasRightChild(int i) => GetRightChildIndex(i) < position;
        protected bool IsRoot(int i) => i == 0;
        protected T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        protected T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        protected T GetParent(int i) => Array[GetParentIndex(i)];
        public bool IsEmpty => position == 0;
        public T Peek()
        {
            if(IsEmpty)
                throw new ArgumentNullException(nameof(IsEmpty));
            return Array[0];
        }

        public void Swap(int first, int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }
        public void Add(T value)
        {
            if(position == Array.Length)
                throw new IndexOutOfRangeException(nameof(position));
            Array[position++] = value;
            Count++;
            HeapifyUp();
        }
        public T DeleteMinMax()
        {
            var temp = Array[0];
            Array[0] = Array[--position ]; //Köke taşıma işlemi yapılacak
            Count--;
            HeapifyDown();
            return temp;
        }

        protected abstract void HeapifyUp();
        protected abstract void HeapifyDown();

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
