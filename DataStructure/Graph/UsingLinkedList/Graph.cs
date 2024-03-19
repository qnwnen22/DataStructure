using System;
using System.Collections.Generic;

namespace DataStructure.Graph.UsingLinkedList
{
    public class Graph
    {
        private List<Node> nodes = new List<Node>();

        public Node AddVertex(string key)
        {
            var node = new Node(key);
            nodes.Add(node);
            return node;
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            Node fromVertex = nodes.Find(s => s.Key == from);

            var edge = new Edge(from, to, weight);
            fromVertex.EdgeList.AddFirst(edge);
        }

        internal void DebugPrintGraph()
        {
            foreach (var vertex in nodes)
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
