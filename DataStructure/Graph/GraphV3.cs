using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Graph
{
    public class GraphV3
    {
        public class Node : IComparable
        {
            public string Key { get; }
            public List<Edge> EdgeList { get; set; }
            public Node(string key)
            {
                this.Key = key;
                this.EdgeList = new List<Edge>();
            }

            public int CompareTo(object _object)
            {
                Node other = (Node)_object;
                return this.Key.CompareTo(other.Key);
            }
        }

        public class Edge
        {
            public string From { get; }
            public string To { get; }
            public int Weight { get; set; }
            public Edge(string from, string to, int weight = 0)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }
        }

        private List<Node> nodes = new List<Node>();
        private bool directedGraph;

        public GraphV3(bool directedGraph = false)
        {
            this.directedGraph = directedGraph;
        }

        public Node AddVertex(string key)
        {
            var node = new Node(key);
            nodes.Add(node);
            return node;
        }

        public void AddEdge(string from, string to, int weight = 0)
        {
            Node fromVtx = nodes.Find(s => s.Key == from);
            var edge1 = new Edge(from, to, weight);
            fromVtx.EdgeList.Add(edge1);

            if (!directedGraph)
            {
                var toVtx = nodes.Find(x => x.Key == to);
                var edge2 = new Edge(to, from, weight);
                toVtx.EdgeList.Add(edge2);
            }
        }

        public void PrimMST()
        {
            // MST 결과집합
            var mst = new List<Edge>();

            // 방문노드집합
            var visited = new HashSet<Node>();

            // 임의의 시작노드 선택
            visited.Add(nodes[0]);

            // 모든 노드를 방문할 때까지 루프
            while (visited.Count < nodes.Count)
            {
                int minWeight = int.MaxValue;
                Edge minEdge = null;

                // 방문노드집합에 속한 정점들의 인접노드들중
                // 가중치가 가장 낮은 간선 선택
                foreach (Node curr in visited)
                {
                    // 노드의 인접간선들 체크
                    foreach (var edge in curr.EdgeList)
                    {
                        //방문노드집합들을 향하지 않는 간선 중
                        if (visited.FirstOrDefault(n => n.Key == edge.To) == null)
                        {
                            // 최소 가중치 간선 선택
                            if (edge.Weight < minWeight)
                            {
                                minWeight = edge.Weight;
                                minEdge = edge;
                            }
                        }
                    }
                }

                // MST와 방문노드집합에 추가
                Node minNode = nodes.Single(n => n.Key == minEdge.To);
                visited.Add(minNode);
                mst.Add(minEdge);
            }

            // 결과 출력
            foreach (var m in mst)
            {
                Console.WriteLine($"{m.From}-{m.To} {m.Weight}");
            }
        }

        public void Dijkstra(Node start)
        {
            // Dijkstra 테이블 초기화
            var totalCosts = new Dictionary<Node, int>();
            var prevNodes = new Dictionary<Node, Node>();

            foreach (var n in nodes)
            {
                totalCosts.Add(n, int.MaxValue);
                prevNodes.Add(n, null);
            }

            // 시작정점 데이타 초기화
            totalCosts[start] = 0;
            prevNodes[start] = start;

            // 방문노드집합에 시작정점 추가
            var visited = new HashSet<Node>();
            visited.Add(start);

            // 모든 노드를 방문할 때까지 루프
            while (visited.Count < nodes.Count)
            {
                int minWeight = int.MaxValue;
                Node minNode = null;

                // 방문노드집합의 인접 노드들에 대해
                // (1) 새 경로 가중치를 갱신하고
                // (2) 경로 가중치가 최소인 minNode를 선택한다
                foreach (Node curr in visited)
                {
                    foreach (Edge edge in curr.EdgeList)
                    {
                        Node destNode = nodes.Single(n => n.Key == edge.To);

                        if (!visited.Contains(destNode))
                        {
                            // 새 경로 가중치가 기본값보단 작으면 갱신
                            int nodeWeight = totalCosts[curr] + edge.Weight;
                            if (nodeWeight < totalCosts[destNode])
                            {
                                totalCosts[destNode] = nodeWeight;
                                prevNodes[destNode] = curr;
                            }
                            else
                            {
                                nodeWeight = totalCosts[destNode];
                            }

                            // 인접노드들 중 경로 가중치가 최소인 노드 선택
                            if (nodeWeight < minWeight)
                            {
                                minWeight = nodeWeight;
                                minNode = destNode;
                            }
                        }
                    }

                }

                // 경로 가중치가 최소인 노드를 방문노드집합에 추가
                visited.Add(minNode);
            }

            foreach (var n in nodes)
            {
                Console.WriteLine($"{n.Key} : {totalCosts[n]} / {prevNodes[n].Key}");
            }
        }
    }
}
