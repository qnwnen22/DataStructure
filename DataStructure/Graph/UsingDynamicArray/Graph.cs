using System;
using System.Collections.Generic;

namespace DataStructure.Graph.UsingDynamicArray
{
    public class Graph<T>
    {
        private List<Node<T>> nodes;
        private bool directedGraph;

        public Graph(bool directedGraph = false)
        {
            this.nodes = new List<Node<T>>();
            this.directedGraph = directedGraph;
        }

        public Node<T> AddVertex(T data)
        {
            return AddVertex(new Node<T>(data));
        }

        public Node<T> AddVertex(Node<T> node)
        {
            nodes.Add(node);
            return node;
        }

        public void AddEdge(Node<T> from, Node<T> to, int weight = 1)
        {
            from.Neighbors.Add(to);
            from.Weights.Add(weight);
            if (!directedGraph)
            {
                to.Neighbors.Add(from);
                to.Weights.Add(weight);
            }
        }

        internal void DebugPrintGraph()
        {
            foreach (var vertex in nodes)
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
            // 방문 여부를 표시하는 방문테이블
            var visited = new HashSet<Node<T>>();

            // Disconnected Graph 를 위해
            // 방분하지 않은 노드를 모두 체크
            foreach (var node in nodes)
            {
                if (!visited.Contains(node))
                {
                    DFSRecursive(node, visited);
                    Console.WriteLine();
                }
            }
        }

        private void DFSRecursive(Node<T> node, HashSet<Node<T>> visited)
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
            var visited = new HashSet<Node<T>>();

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

        private void DFSUsingStack(Node<T> node, HashSet<Node<T>> visited)
        {
            var stack = new Stack<Node<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (!visited.Contains(vertex))
                {
                    Console.Write("{0} ", vertex.Data);
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

                //// 표현(B)
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
            var visited = new HashSet<Node<T>>();

            // Disconnected Graph 를 위해
            // 방문하지 않은 노드들 모두 체크
            foreach (var node in nodes)
            {
                if (!visited.Contains(node))
                {
                    BFS(node, visited);
                }
            }
        }

        private void BFS(Node<T> node, HashSet<Node<T>> visited)
        {
            var q = new Queue<Node<T>>();
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
        }



        private void TopoSort(Node<T> node, HashSet<Node<T>> visited, Stack<Node<T>> result)
        {
            foreach (var nbr in node.Neighbors)
            {
                if (!visited.Contains(nbr))
                {
                    TopoSort(nbr, visited, result);
                }
            }

            // (A) 스택에 저장하는 경우
            result.Push(node);
            // (B) 연결리스트에 저장하는 경우
            // result.AddFirst(node);
            visited.Add(node);
        }

        public Stack<Node<T>> TopologicalSort()
        {
            var visted = new HashSet<Node<T>>();
            //(A)스택에 저장하는 경우
            var result = new Stack<Node<T>>();
            //(B) 연결리스트에 저장하는 경우       
            //var result = new LinkedList<Node<T>>();
            // 모든 노드에 대해        
            // 방문하지 않은 경우 위상정렬 수행    
            foreach (var vertex in nodes)
            {
                if (!visted.Contains(vertex))
                {
                    TopoSort(vertex, visted, result);
                }
            }
            return result;
        }
    }
}
