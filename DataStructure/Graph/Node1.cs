using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class Node1<T>
    {
        public T Data { get; set; }
        public List<Node1<T>> Neighbors { get; private set; }
        public List<int> Weights { get; private set; } // Optional

        public Node1()
        {
            Neighbors = new List<Node1<T>>();
            Weights = new List<int>();
        }

        public Node1(T data) : this()
        {
            this.Data = data;
        }
    }

    public class Graph<T>
    {
        private List<Node1<T>> nodes;
        private bool directedGraph;

        public Graph(bool directedGraph = false)
        {
            this.nodes = new List<Node1<T>>();
            this.directedGraph = directedGraph;
        }

        public Node1<T> AddVertex(T data)
        {
            return AddVertex(new Node1<T>(data));
        }

        private Node1<T> AddVertex(Node1<T> node)
        {
            nodes.Add(node);
            return node;
        }

        public void AddEdge(Node1<T> from, Node1<T> to, int weight = 1)
        {
            from.Neighbors.Add(to);
            from.Weights.Add(weight);
            if (directedGraph == false)
            {
                to.Neighbors.Add(from);
                to.Weights.Add(weight);
            }
        }

        internal void DebugPrintGraph()
        {
            foreach (Node1<T> vertex in nodes)
            {
                int cnt = vertex.Neighbors.Count;
                for (int i = 0; i < cnt; i++)
                {
                    Console.WriteLine("{0}-- ({1}) --{2}", vertex.Data, vertex.Weights[i], vertex.Neighbors[i].Data);
                }
            }
        }
    }
}
