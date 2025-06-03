using System.Collections;

namespace MyDataStructures.LinkedList.MySinglyLinkedList
{
    public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T>? Head;
        private SinglyLinkedListNode<T> _current;
        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
            _current = null;
        }

        public T Current => _current.Item == null ? throw new NullReferenceException() : _current.Item;

        object IEnumerator.Current => Current == null ? throw new NullReferenceException() : Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if(_current == null)
            {
                _current = Head == null ? throw new NullReferenceException() : Head;
                return true;
            }
            else
            {
                _current = _current.Next;
                return _current != null ? true : false;
            }
        }

        public void Reset()
        {
            _current = null;
        }
    }
}