using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Tree.CST
{
    public class CST : IEnumerable
    {
        public NodeCST Root { get; private set; }
        public CST()
        {
            CreateTree();
        }

        private void CreateTree()
        {
            Root = new NodeCST(default(char));
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Add(NodeCST root,char character,bool isPointer = false)
        {
            if (character == null) throw new ArgumentNullException();
            var newNode = new NodeCST(character,isPointer);
            var ptr = root;
            while (true)
            {
                try
                {
                    ptr.Childs.Add(character, newNode);
                    break;
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
        public void Add(string sentence)
        {
            if (sentence == null) throw new ArgumentNullException();
            NodeCST current = Root;
            for (int i = 0; i < sentence.Length; i++)
            {
                char temp = char.ToLower(sentence[i]);
                if (temp >= 97 && temp <= 122)
                {
                    if ((i + 1) < sentence.Length && char.ToLower(sentence[i + 1]) >= 97 && char.ToLower(sentence[i + 1]) <= 122)
                    {
                        Add(current,temp);
                    }
                    else
                    {
                        Add(current,temp,true);
                    }
                    current = current.Childs[temp];
                }
                else
                {
                    current = Root;
                }
            }
        }
        public bool Find(string sentence) 
        {
            if (sentence == null) throw new ArgumentNullException();
            NodeCST current = Root;
            string temp = sentence.ToLower();
            for (int i = 0; i < temp.Length; i++)
            {
                if (current.Childs.ContainsKey(temp[i]))
                {
                    current = current.Childs[temp[i]];
                    if ((i+1) > temp.Length - 1) 
                    {
                        return current.Pointer; 
                    }
                }
            }
            return false;
        }
        public Queue<string> toSeparate(string sentence) //0>O(n) n : cümlede karakter sayısı
        {
            Queue<string> strings = new();
            Queue<char> chars = new();
            for (int i = 0; i < sentence.Length; i++)
            {
                char tempChar = char.ToLower(sentence[i]);
                if (tempChar >= 97 && tempChar <= 122)
                {
                    if ((i + 1) < sentence.Length && char.ToLower(sentence[i + 1]) >= 97 && char.ToLower(sentence[i + 1]) <= 122)
                    {
                        chars.Enqueue(tempChar);
                    }
                    else
                    {
                        chars.Enqueue(tempChar);
                        string tempStr = "";
                        while (chars.Count > 0)
                        {
                            tempStr += chars.Dequeue();
                        }
                        strings.Enqueue(tempStr);
                    }
                }
            }
            return strings;
        }
        public string Censor(string sentence)
        {
            Queue<string> seperateSentence = toSeparate(sentence); // => O(n)
            string newSentence = "";
            while (seperateSentence.Count > 0) // => O(m) m: Kelime sayısı
            {
                var control = seperateSentence.Dequeue().ToLower();
                if (Find(control)) // => o(L) L = gönderilen kelimenin karakter sayısı. 50
                {
                    control = "***"; //=> O(m) + O(n) => O(n)
                }
                newSentence += control + " ";
            }
            return newSentence;
        }
    }
}
