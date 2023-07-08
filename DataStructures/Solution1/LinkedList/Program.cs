using MyDataStructures.LinkedList.MySinglyLinkedList;
SinglyLinkedListNode<int> a = new(1111);
SinglyLinkedListNode<int> b = new(2111);
SinglyLinkedList<int> myLinkedList = new SinglyLinkedList<int>();
myLinkedList.AddFirst(120);
myLinkedList.AddFirst(98);
myLinkedList.AddLast(982);
// 58 , 98 , 120 , 1111 , 100 , 982 
myLinkedList.AddAfter(myLinkedList.Head.Next, 100);
myLinkedList.AddBefore(myLinkedList.Head, 58);
myLinkedList.AddAfter(myLinkedList.Head.Next.Next, a);

foreach (int i in myLinkedList)
{
    Console.WriteLine(i);
}

Console.ReadLine();
