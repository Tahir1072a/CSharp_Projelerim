namespace MyDataStructures.Tree.BinaryTrees.BHeap
{
    public class MinHeap<T> : BHeapTree<T>, IEnumerable<T> where T : IComparable
    {
        public MinHeap() : base()
        {
            
        }
        public MinHeap(int size) : base(size)
        {
            
        }
        public MinHeap(IEnumerable<T> collection) : base(collection)
        {
            
        }
        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetLeftChild(index).CompareTo(GetRightChild(index)) > 0)
                {
                    smallerIndex = GetRightChildIndex(index);
                }
                if (Array[smallerIndex].CompareTo(Array[index]) >= 0) break;
                Swap(smallerIndex, index);
                index = smallerIndex;
            }

        }

        protected override void HeapifyUp()
        {
            int index = position - 1;
            while(index != 0)
            {
                int smallerIndex = GetParentIndex(index);
                if (GetParent(index).CompareTo(Array[index]) <= 0)
                {
                    break;
                }
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
    }
}
