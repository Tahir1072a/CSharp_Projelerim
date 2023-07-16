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
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
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
