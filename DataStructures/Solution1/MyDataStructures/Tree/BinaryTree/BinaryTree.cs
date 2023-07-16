using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Tree
{
    public class BinaryTree<T> where T : IComparable
    {
        public List<Node<T>> list { get; private set; }
        private bool IsFirstCall = true;
        public BinaryTree()
        {
            list = new List<Node<T>>();
        }
        private List<Node<T>> InOrder(Node<T> root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }
        private List<Node<T>> PreOrder(Node<T> root)
        {
            if (root != null)
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
            return list;
        }
        private List<Node<T>> PostOrder(Node<T> root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }
        public List<Node<T>> InOrderIter(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            var S = new Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode != null) { S.Push(currentNode); currentNode = currentNode.Left; }
                else
                {
                    if (S.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return list;
        }
        public List<Node<T>> PreOrderIte(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            if (root == null) throw new Exception();
            Stack<Node<T>> S = new Stack<Node<T>>();
            S.Push(root);
            while (S.Count != 0)
            {
                Node<T> temp = S.Pop();
                list.Add(temp);
                if (temp.Right != null) { S.Push(temp.Right); }
                if (temp.Left != null) { S.Push(temp.Left); }
            }
            return list;
        }
        public List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            //2 tane stack oluşturuyoruz çünkü 2. stack de dönüm noktalarını saklayacağız.
            var S = new Stack<Node<T>>();
            var S2 = new Stack<Node<T>>();
            var currentNode = root; //Başlangıç Node
            while (true)
            {
                if (currentNode != null) { S.Push(currentNode); currentNode = currentNode.Left; } //Ağaçta en son değere kadar gidiyoruz.
                else  //Sooldaki en son değeri bulunca buraya giriyoruz.
                {
                    currentNode = S.Peek(); //Stack içinden elemanı silmeden currentNode ekliyoruz, bu en sondaki eleman oluyor.
                    S2.Push(currentNode); // Artık bu dönüm noktası oluyor çünkü onun sağına bakmamız gerekiyor.
                    if (currentNode.Right != null) { currentNode = currentNode.Right; } //Sağında eleman var ise current sağ tarafa geçiyor.
                    else
                    {
                        //Döngü, S2 içindeki tepe eleman ile S içindeki tepe eleman eşit olduğu sürece döner. 
                        while (S2.Count > 0 && S.Count > 0 && S.Peek() == S2.Peek()) //Eğer dönüm noktasının sağında eleman yok ise döngü koşulna bakıyoruz
                        {
                            list.Add(S2.Pop()); //Eşit elemanı listeye ekliyoruz.
                            S.Pop(); //Diğer listeden de çıkartıyoruz.
                        }
                        if (S.Count == 0) break; //S içinde eleman kalmadıysa işlem bitiyor.
                        currentNode = S.Peek(); //Bir üst elemana geçiş yapıyoruz. 
                        S2.Push(currentNode); //Artık bu eleman bir dönüm noktası çünkü önceden solu kontrol edilmişti.
                        currentNode = currentNode.Right; //Sağ tarafa geçiiş yapıyoruz.
                    }
                }
            }
            return list;
        }
        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            var Q = new Queue<Node<T>>();
            Q.Enqueue(root);
            while (Q.Count > 0)
            {
                var temp = Q.Dequeue();
                list.Add(temp);
                if (temp.Left != null) { Q.Enqueue(temp.Left); }
                if (temp.Right != null) { Q.Enqueue(temp.Right); }
            }
            return list;
        }
        public static int MaxDepht(Node<T> root)
        {
            if(root == null) return 0;
            int leftDepht = MaxDepht(root.Left);
            int rightDepht = MaxDepht(root.Right);

            return (leftDepht > rightDepht) ? leftDepht + 1 : rightDepht + 1;
        }
        public static Node<T> DeepstDephtNode(Node<T> root)
        {
            Node<T> temp = null;
            if (root == null) throw new Exception();

            var Q = new Queue<Node<T>>();
            Q.Enqueue(root);
            while (Q.Count > 0)
            {
                temp = Q.Dequeue();
                if (temp.Left != null)
                    Q.Enqueue(temp.Left);
                if (temp.Right != null)
                    Q.Enqueue(temp.Right);
            }
            return temp;
        }
        public static int NumberOfFullNodes(Node<T> root) => new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root).Where(x => (x.Left != null && x.Right != null))
            .ToList().Count;
        public static int NumberOfHalfNodes(Node<T> root) => new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root).Where(x => (x.Left == null && x.Right != null) || (x.Left != null && x.Right == null))
            .ToList().Count;
        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }

        private void PrintPaths(Node<T> root, T[] path, int pathLenght)
        {
            if(root == null) return;
            path[pathLenght] = root.Value;
            pathLenght++;

            if(root.Left == null && root.Right == null) 
            {
                PrintArray(path, pathLenght);
            }
            else
            {
                PrintPaths(root.Left, path, pathLenght);
                PrintPaths(root.Right, path, pathLenght);
            }
        }
        private void PrintArray(T[] path, int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{path[i]} ");
            }
            Console.WriteLine();
        }

        public static int NumberOfLeafs(Node<T> root)
        {
            /* Algorithms
            int count = 0;
            if (root == null) return count;
            var Q = new Queue<Node<T>>();
            Q.Enqueue(root);
            while(Q.Count > 0)
            {
                var temp = Q.Dequeue();
                if (temp.Left == null && temp.Right == null)
                    count++;
                if(temp.Left != null)
                {
                    Q.Enqueue(temp.Left);
                }
                if(temp.Right != null)
                {
                    Q.Enqueue(temp.Right);
                }
            }
            return count;
            */
            #region Alternatif
            return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root).Where(p=> (p.Left == null&&p.Right == null)).ToList().Count;
            #endregion
        }
        public List<Node<T>> GetListPostOrder(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            return PostOrder(root);
        }
        public List<Node<T>> GetListInOrder(Node<T> root)
        {
            if (list.Count > 0) ClearList();

            return InOrder(root);
        }
        public List<Node<T>> GetListOfMember(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            return PreOrder(root);
        }
        public void ClearList() => list.Clear();
    }
}
