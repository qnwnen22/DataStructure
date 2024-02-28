namespace DataStructure.Graph
{
    public class Node2
    {
        public int Data { get; set; }
        // 고정배열
        public Node2[] Neighbors { get; set; }
    }

    public class Graph2
    {
        // 고정배열
        private Node2 nodes;
        // ... 
    }
}
