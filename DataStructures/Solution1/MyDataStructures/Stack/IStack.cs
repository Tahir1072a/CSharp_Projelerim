using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Stack
{
    public interface IStack<T>
    {
        int Count { get; }
        void Push(T value);
        T Pop();
        T Peek();
    }
}
