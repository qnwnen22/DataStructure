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


        public void DFS()
        {
            // 방문 여부를 표시하는 방문 테이블
            var visited = new HashSet<Node1<T>>();

            // Disconnected Graph 를 위해
            // 방문하지 않은 노드를 모두 체크
            foreach (var node in nodes)
            {
                if (!visited.Contains(node))
                {
                    DFSRecursive(node, visited);
                    Console.WriteLine();
                }
            }
        }

        private void DFSRecursive(Node1<T> node, HashSet<Node1<T>> visited)
        {
            // 노드 방문
            Console.Write("{0} ", node.Data);
            visited.Add(node);

            foreach (var adjNode in node.Neighbors)
            {
                // 이미 방문하지 않은 인접 노드에 대해서만
                if (!visited.Contains(adjNode))
                {
                    // 재귀호출
                    DFSRecursive(adjNode, visited);
                }
            }
        }


        public void DFSIterative()
        {
            var visited = new HashSet<Node1<T>>();

            // Disconnected Graph 를 위해
            // 방문하지 않은 노드들 모두 체크
            foreach (var node in nodes)
            {
                if (!visited.Contains(node))
                {
                    DFSUsingStack(node, visited);
                }
            }
        }

        private void DFSUsingStack(Node1<T> node, HashSet<Node1<T>> visited)
        {
            var stack = new Stack<Node1<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (!visited.Contains(vertex))
                {
                    Console.WriteLine("{0} ", vertex.Data);
                    visited.Add(vertex);
                }

                // 표현(A)
                foreach (var adjNode in vertex.Neighbors)
                {
                    if (!visited.Contains(adjNode))
                    {
                        stack.Push(adjNode);
                    }
                }

                // 표현(B)
                //int cnt = vertex.Neighbors.Count;
                //for (int i = cnt - 1; i >= 0; i--)
                //{
                //    if (!visited.Contains(vertex.Neighbors[i]))
                //    {
                //        stack.Push(vertex.Neighbors[i]);
                //    }
                //}
            }
            Console.WriteLine();
        }

        public void BFS()
        {
            var visited = new HashSet<Node1<T>>();

            // Disconnected Graph 를 위해
            // 방문하지 않은 노드를 모두 체크
            foreach (Node1<T> node in nodes)
            {
                if (!visited.Contains(node))
                {
                    BFS(node, visited);
                }
            }
        }

        private void BFS(Node1<T> node, HashSet<Node1<T>> visited)
        {
            var q = new Queue<Node1<T>>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                var vertex = q.Dequeue();

                // 노드 방문
                if (!visited.Contains(vertex))
                {
                    Console.Write("{0} ", vertex.Data);
                    visited.Add(vertex);
                }

                foreach (var adjNode in vertex.Neighbors)
                {
                    // 이미 방문하지 않은 인접 노드에 대해
                    if (!visited.Contains(adjNode))
                    {
                        // Queue에 추가
                        q.Enqueue(adjNode);
                    }
                }
            }

            // BFS 실행 결과 : 
            // A B D E C F G X Y
        }
    }
}
