using System;
using System.Collections.Generic;

namespace DataStructure.Graph.UsingHashtable
{
    public class Graph
    {
        private Dictionary<string, List<Node>> nodes = new Dictionary<string, List<Node>>();
        public void AddVertex(string key)
        {
            if (nodes.ContainsKey(key) == false)
            {
                var edgeList = new List<Node>();
                // Add empty edge list
                nodes.Add(key, edgeList);
            }
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            var edgeList = nodes[from];
            if (edgeList == null)
            {
                throw new Exception("Not found");
            }
            edgeList.Add(new Node(to, weight));
        }

        internal void DebugPrintGraph()
        {
            foreach (KeyValuePair<string, List<Node>> kv in nodes)
            {
                // 시작 정점 키
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
