using MyDataStructures.Tree.BinaryTrees.BHeap;
Random rnd = new Random();
int[] ints = new int[30000000];


var heap = new MinHeap<int>();
heap.Add(4);
heap.Add(1);
heap.Add(10);
heap.Add(8);
heap.Add(7);
heap.Add(5);
heap.Add(9);
heap.Add(3);
heap.Add(2);
heap.DeleteMinMax();


var maxHeap = new MaxHeap<int>();
maxHeap.Add(4);
maxHeap.Add(1);
maxHeap.Add(10);
maxHeap.Add(8);
maxHeap.Add(7);
maxHeap.Add(5);
maxHeap.Add(9);
maxHeap.Add(3);
maxHeap.Add(2);
maxHeap.DeleteMinMax();
Console.ReadLine();