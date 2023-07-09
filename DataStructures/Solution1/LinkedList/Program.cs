using MyDataStructures.LinkedList.MySinglyLinkedList;
SinglyLinkedListNode<int> a = new(1111);

int[] arr = new int[] { 20,30,52,26,25,212,74};

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

Console.ReadLine();
