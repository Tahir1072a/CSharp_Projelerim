using System;
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
            var S = new Stack<Node<T>>();
            var S2 = new Stack<Node<T>>();
            var currentNode = root;
            while (true)
            {
                if (currentNode != null) { S.Push(currentNode); currentNode = currentNode.Left; }
                else
                {
                    if (S.Count == 0) break;
                    else
                    {
                        currentNode = S.Peek();
                        S2.Push(currentNode);
                        if (currentNode.Right != null) { currentNode = currentNode.Right; }
                        else
                        {
                            while(S2.Count > 0 && S.Count > 0 && S.Peek() == S2.Peek()) 
                            {
                                list.Add(S2.Pop());
                                S.Pop();
                            }
                            if (S.Count == 0) break;
                            currentNode = S.Peek();
                            S2.Push(currentNode);
                            currentNode = currentNode.Right;
                        }
                    }
                }
            }
            return list;
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
