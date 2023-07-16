using MyDataStructures.Tree;

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

BinaryTree<int> instance = new BinaryTree<int>();
foreach (var item in instance.GetListPostOrder(denem.Root))
{
    Console.WriteLine(item);
}
Console.WriteLine("-----------------------------------------");
foreach (var item in instance.PostOrderNonRecursiveTraversal(denem.Root))
{
    Console.WriteLine(item);
} 

Console.ReadLine();