﻿using System.Collections;

namespace MyDataStructures.Tree.BinaryTrees
{
    public class BSTEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private List<Node<T>> list;
        private int indexer = -1;

        public T Current => list[indexer].Value;

        object IEnumerator.Current => Current;
        public BSTEnumerator(Node<T> root)
        {
            list = BinaryTree<T>.InOrderIter(root);
        }
        public void Dispose()
        {
            list = null;
        }

        public bool MoveNext()
        {
            indexer++;
            return indexer < list.Count;
        }

        public void Reset()
        {
            indexer = -1;
        }
    }
}