namespace MyDataStructures.Tree.BinaryTrees.BHeap
{
    public class MaxHeap<T> : BHeapTree<T>, IEnumerable<T> where T : IComparable
    {
        public MaxHeap() : base()
        {

        }
        public MaxHeap(int size) : base(size)
        {

        }
        public MaxHeap(IEnumerable<T> collection) : base(collection)
        {

        }
        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var biggerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetLeftChild(index).CompareTo(GetRightChild(index)) < 0)
                {
                    biggerIndex = GetRightChildIndex(index);
                }
                if (Array[biggerIndex].CompareTo(Array[index]) <= 0) break;
                Swap(biggerIndex, index);
                index = biggerIndex;
            }

        }

        protected override void HeapifyUp()
        {
            int index = position - 1;
            while (index != 0)
            {
                int biggerIndex = GetParentIndex(index);
                if (GetParent(index).CompareTo(Array[index]) >= 0)
                {
                    break;
                }
                Swap(biggerIndex, index);
                index = biggerIndex;
            }
        }
    }
}
