namespace DataStructure.Graph.UsingLinkedList
{
    public class Edge
    {
        public string From { get; }
        public string To { get; }
        public int Weight { get; set; }
        public Edge(string from, string to, int weight = 1)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }
    }
}
