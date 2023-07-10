using MyDataStructures.LinkedList.MyDoublyLinkedList;
using MyDataStructures.LinkedList.MySinglyLinkedList;
using MyDataStructures.Queue;
using MyDataStructures.Stack;

SinglyLinkedListNode<int> a = new(1111);

int[] arr = new int[] { 20};

SinglyLinkedList<int> myLinkedList = new SinglyLinkedList<int>(arr);
SinglyLinkedList<int> myLinkedList2 = new SinglyLinkedList<int>(arr);
SinglyLinkedList<SinglyLinkedList<int>> myLinkedList3 = new SinglyLinkedList<SinglyLinkedList<int>>();
myLinkedList3.AddFirst(myLinkedList2);
myLinkedList3.AddFirst(myLinkedList);
myLinkedList.AddFirst(120);
myLinkedList.AddFirst(98);
myLinkedList.AddLast(982);
// 58 , 98 , 120 , 1111 , 100 , 982 
myLinkedList.AddAfter(myLinkedList.Head.Next, 100);
myLinkedList.AddBefore(myLinkedList.Head, 58);
myLinkedList.AddAfter(myLinkedList.Head.Next.Next, a);

Console.WriteLine($"{myLinkedList.RemoveLast()} has been removed");
Console.WriteLine($"{myLinkedList.RemoveLast()} has been removed");
Console.WriteLine($"{myLinkedList.RemoveLast()} has been removed");

myLinkedList.Remove(58);
myLinkedList.Remove(120);

DoubleLinkedList<int> listem = new();
listem.AddFirst(10);
listem.AddFirst(20);
listem.AddFirst(1);
listem.RemoveFirst();
listem.RemoveFirst();

MyDataStructures.Queue.Queue<int> queue = new MyDataStructures.Queue.Queue<int>(QueueType.LinkedList);
queue.EnQueue(1);
queue.EnQueue(2);
queue.EnQueue(3);
queue.EnQueue(4);
queue.DeQueue();
MyDataStructures.Stack.Stack<int> stack = new MyDataStructures.Stack.Stack<int>(StackType.LinkedList);
stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Pop();

Console.ReadLine();
