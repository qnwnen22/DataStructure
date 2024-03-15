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
            Preorder(node, prefix, results);

            return results;
        }

        private void Preorder(Node node, string nodeStr, List<string> results)
        {
            if (node == null) return;

            // 단어끝이면 리스트에 추가
            if (node.EndOfWord)
            {
                results.Add(nodeStr);
            }

            // Children들을 Preorder 재귀 호출
            foreach (char key in node.Children.Keys)
            {
                Preorder(node.Children[key], nodeStr + key, results);
            }
        }

       

        public void Delete(string word)
        {
            Delete(root, word, 0);
        }

        private bool Delete(Node current, string word, int index)
        {
            if (index == word.Length)
            {
                if (!current.EndOfWord)
                {
                    return false; // Trie에서 단어를 찾을 수 없습니다.
                }
                current.EndOfWord = false;
                return current.Children.Count == 0; // 현재 노드에 다른 매핑이 없으면 true를 반환합니다.
            }

            char ch = word[index];
            if (!current.Children.ContainsKey(ch))
            {
                return false; // Trie에서 단어를 찾을 수 없습니다.
            }

            bool shouldDeleteCurrentNode = Delete(current.Children[ch], word, index + 1);

            // true가 반환되면 문자와 TrieNode 참조의 매핑을 맵에서 삭제합니다.
            if (shouldDeleteCurrentNode)
            {
                current.Children.Remove(ch);
                // 맵에 매핑이 남아 있지 않으면 true를 반환합니다.
                return current.Children.Count == 0;
            }
            return false;
        }
    }
}
