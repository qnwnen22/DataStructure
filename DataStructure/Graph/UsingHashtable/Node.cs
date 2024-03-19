namespace DataStructure.Graph.UsingHashtable
{
    public class Node
    {
        public string Key { get; set; }
        public int Weight { get; set; }
        public Node(string key, int weight = 1)
        {
            Key = key;
            Weight = weight;
        }
    }
}
