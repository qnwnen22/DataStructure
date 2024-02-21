using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trie
{
    public class Trie2
    {
        private class Node
        {
            public Dictionary<char, Node> Children { get; private set; }
            // public bool EndOfWord { get; set; }
            public string Word { get; set; }
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

            // 단어를 노드에 저장
            node.Word = str;
        }

        public List<string> AutoComplete(string prefix)
        {
            // Prefix 까지의 노드로 이동
            Node node = root;
            foreach (char ch in prefix)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return null;
                }
                node = node.Children[ch];
            }

            // Prefix 노드부터 전위순회
            var results = new List<string>();
            Preorder(node, results);

            return results;
        }

        private void Preorder(Node node, List<string> results)
        {
            if (node == null) return;

            // 단어끝이면 리스트에 추가
            if (node.Word != null)
            {
                results.Add(node.Word);
            }

            // Children들을 Preorder 재귀 호출
            foreach (char key in node.Children.Keys)
            {
                Preorder(node.Children[key], results);
            }
        }
    }
}
