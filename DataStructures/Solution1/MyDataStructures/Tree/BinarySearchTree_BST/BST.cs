using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Tree
{
    public class BST<T> : IEnumerable<T> where T : IComparable
    {
        public Node<T> Root { get; private set; }
        public BST()
        {
            
        }
        public BST(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        /// <summary>
        /// Dallara Sıralı bir şekilde ekleme işlemi yapar. Değer root dan büyük ise sağa,küçük ise sola eklenir.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Validate(value);
            if (Root == null)
            {
                Root = new Node<T>(value);
                return;
            }
            var newNode = new Node<T>(value);
            var ptr = Root;
            while(true)
            {
                var parent = ptr;
                if(ptr.Value.CompareTo(value) < 0) //İlgili değer, node'da bulunan değerden sonra geliyorsa sağ dala geçilir.
                {
                    ptr = ptr.Right;
                    if(ptr == null)
                    {
                        parent.Right = newNode;
                        break;
                    }
                }
                else
                {
                    ptr = ptr.Left;  //İlgili değer, node'da bulunan değerden önce geliyorsa sol dala geçilir.
                    if( ptr == null)
                    {
                        parent.Left = newNode;
                        break;
                    }
                }
            }
            ptr = newNode;
        }
        public T FindMin(Node<T> root)
        {
            var current = root;
            while (current.Left != null) { current = current.Left; }
            return current.Value;
        }
        public T FindMax(Node<T> root)
        {
            var current = root;
            while (current.Right != null) { current = current.Right; }
            return current.Value;
        }
        public Node<T> Find(Node<T> root, T value)
        {
            var current = root;
            while (value.CompareTo(current.Value) != 0)
            {
                if(value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
                if(current == null)
                {
                   return default(Node<T>);
                }
            }
            return current;
        }
        public Node<T> Remove(Node<T> root,T value)
        {
            if (root == null)
                return null;
            if(value.CompareTo(root.Value) < 0)
            {
                root.Left = Remove(root.Left, value);
            }
            else if(value.CompareTo(root.Value) > 0)
            {
                root.Right = Remove(root.Right, value);
            }
            else
            {
                //Tek child ise
                if(root.Left == null)
                {
                    return root.Right;
                }
                else if(root.Right == null)
                {
                    return root.Left;
                }
                //Two child ise 
                root.Value = FindMin(root);
                root.Right = Remove(root.Right, root.Value);
            }
            return root;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator<T>(Root)
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Validate(object? obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));
        }
    }
}
