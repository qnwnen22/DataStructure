using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trie
{
    public class Trie
    {
        private class Node
        {
            public Dictionary<char, Node> Children { get; private set; }
            public bool EndOfWord { get; set; }
            public Node()
            {
                Children = new Dictionary<char, Node>();
            }
        }

        private Node root = new Node();

        public void Insert(string str)
        {
            Node node = root;

            foreach (char ch in str)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new Node();
                }

                node = node.Children[ch];
            }

            node.EndOfWord = true;
        }

        public bool Find(string str)
        {
            Node node = root;

            foreach (char ch in str)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }

                node = node.Children[ch];
            }

            return node != null && node.EndOfWord;
        }
    }
}
