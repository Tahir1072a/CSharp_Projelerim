using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Tree.CST
{
    public class NodeCST
    {
        public bool Pointer { get; set; }
        public Dictionary<char, NodeCST> Childs { get; set; } = new();
        public override string ToString() => $"{Childs}";
        public NodeCST(char value, bool isPoint = false)
        {
            Pointer = isPoint;
        }
    }
}
