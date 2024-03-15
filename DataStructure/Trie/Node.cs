namespace DataStructure.Trie
{
    class Node
    {
        public Node[] Children { get; private set; }
        public bool EndOfWord { get; set; }
        public string Word { get; set; }

        public Node()
        {
            // 알파벳 숫자만큼 노드 배열 생성
            Children = new Node[26];
        }
    }
}
