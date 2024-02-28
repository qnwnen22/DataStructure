using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class Node4
    {
        public string Key { get; }
        public LinkedList<Edge> EdgeList { get; }
        public Node4(string key)
        {
            this.Key = key;
            this.EdgeList = new LinkedList<Edge>();
        }
    }

    public class Edge
    {
        public string From { get; } // Optional
        public string To { get; }
        public int Weight { get; set; }

        public Edge(string from, string to, int weight = 1)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }
    }

    public class Graph4
    {
        private List<Node4> nodes = new List<Node4>();

        public Node4 AddVertex(string key)
        {
            var node = new Node4(key);
            nodes.Add(node);
            return node;
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            Node4 fromVertex = nodes.Find(s => s.Key == from);
            var edge = new Edge(from, to, weight);
            fromVertex.EdgeList.AddFirst(edge);
        }

        internal void DebugPrintGraph()
        {
            foreach (Node4 vertex in nodes)
            {
                string from = vertex.Key;

                foreach (var edge in vertex.EdgeList)
                {
                    Console.WriteLine($"{from}--({edge.Weight})--{edge.To}");
                }
            }
        }
    }
}
