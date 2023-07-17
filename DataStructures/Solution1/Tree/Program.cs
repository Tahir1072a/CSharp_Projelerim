using MyDataStructures.Tree.BinaryTrees;

List<int> bst = new List<int>();
bst.Add(100);
bst.Add(27);
bst.Add(89);
bst.Add(2000);
bst.Add(142);
bst.Add(18);

BST<int> denem = new BST<int>(bst);
denem.Add(100);
denem.Add(2);
denem.Add(30);
denem.Add(4);
denem.Add(500);
denem.Add(6);
denem.Add(2600);
denem.Add(3000);
denem.Add(600);
denem.Add(170);
Console.WriteLine(denem.Remove(denem.Root, 6)); 
foreach (var item in BinaryTree<int>.GetListPostOrder(denem.Root))
{
    Console.WriteLine(item);
}
Console.WriteLine("-----------------------------------------");
foreach (var item in BinaryTree<int>.PostOrderNonRecursiveTraversal(denem.Root))
{
    Console.WriteLine(item);
}
Console.WriteLine("-----------------------------------------");
foreach(var item in denem)
{
    Console.WriteLine(item);
}
Console.WriteLine("-----------------------------------------");
Console.WriteLine(BinaryTree<int>.MaxDepht(denem.Root));
Console.WriteLine(BinaryTree<int>.DeepstNode(denem.Root));
Console.WriteLine(BinaryTree<int>.NumberOfLeafs(denem.Root));
Console.WriteLine(BinaryTree<int>.NumberOfFullNodes(denem.Root));
Console.WriteLine(BinaryTree<int>.NumberOfHalfNodes(denem.Root));
Console.WriteLine("-----------------------------------------");
BinaryTree<int>.PrintPaths(denem.Root);
//Console.WriteLine(denem.Find(denem.Root,300));


Console.ReadLine();