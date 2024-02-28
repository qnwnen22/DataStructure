using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class Node3
    {
        public string Key { get; set; }
        public int Weight { get; set; }
        public Node3(string key, int weight = 1)
        {
            this.Key = key;
            this.Weight = weight;
        }
    }

    public class Graph3
    {
        private Dictionary<string, List<Node3>> nodes = new Dictionary<string, List<Node3>>();
        public void AddVertex(string key)
        {
            if (nodes.ContainsKey(key) == false)
            {
                var edgeList = new List<Node3>();
                // Add empty edge list
                nodes.Add(key, edgeList);
            }
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            List<Node3> edgeList = nodes[from];
            if (edgeList == null)
            {
                throw new Exception();
            }
            edgeList.Add(new Node3(to, weight));
        }

        internal void DebugPrintGraph()
        {
            foreach (KeyValuePair<string, List<Node3>> kv in nodes)
            {
                string from = kv.Key;

                // kv.Value: 시작정점과 연관된 간선들 리스트
                foreach (var edge in kv.Value)
                {
                    Console.WriteLine($"{from}--({edge.Weight})--{edge.Key}");
                }
            }
        }
    }
}
