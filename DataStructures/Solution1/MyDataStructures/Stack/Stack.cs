using MyDataStructures.LinkedList.MySinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Stack
{
    public class Stack<T> 
    {
        private readonly IStack<T> _stack;
        public Stack(StackType type = StackType.Array)
        {
            if(type == StackType.Array)
            {
                _stack = new ArrayStack<T>();
            }
            else if(type == StackType.LinkedList)
            {
                _stack = new LinkedListStack<T>();
            }
        }
        public int Count => throw new NotImplementedException();

        public T Peek()
        {
           return  _stack.Peek();
        }

        public T Pop()
        {
            return _stack.Pop();
        }

        public void Push(T value)
        {
            _stack.Push(value);
        }

        public enum StackType
        {
            Array = 0, // => List<T>
            LinkedList = 1, // => SinglyLinkedList
        }
    }
}
