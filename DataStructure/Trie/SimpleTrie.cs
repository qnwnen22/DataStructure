namespace DataStructure.Trie
{
    public class SimpleTrie
    {
        private class Node
        {
            public Node[] Children { get; private set; }
            public bool EndOfWord { get; set; }
            public Node()
            {
                // 알파벳 숫자만큼 노드 배열 생성
                Children = new Node[26];
            }
        }

        private Node root = new Node();

        public void Insert(string str)
        {
            string s = str.ToLower();
            Node node = root;

            foreach (char ch in s)
            {
                // 문자 위치 구하기
                int index = ch - 'a';

                // 링크가 없으면 새 노드 연결
                if (node.Children[index] == null)
                {
                    node.Children[index] = new Node();
                }

                node = node.Children[index];
            }

            // 단어 끝 표시
            node.EndOfWord = true;
        }

        public bool Find(string str)
        {
            string s = str.ToLower();
            Node node = root;

            foreach (char ch in s)
            {
                int index = ch - 'a';
                if (node.Children[index] == null)
                {
                    return false;
                }
                node = node.Children[index];
            }

            return node != null && node.EndOfWord;
        }
    }
}
