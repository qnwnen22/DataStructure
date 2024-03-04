using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Graph
{
    public class GraphV2
    {
        public class Edge
        {
            public string From { get; }
            public string To { get; }
            public int Weight { get; }
            public Edge(string from, string to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }
        }

        // G = (V, E)
        private readonly List<string> vertices;
        private readonly List<Edge> edges;
        private bool directedGraph = false;

        public GraphV2(IEnumerable<string> vertices, bool directedGraph = false)
        {
            this.vertices = new List<string>(vertices);
            this.edges = new List<Edge>();
            this.directedGraph = directedGraph;
        }

        public void AddEdge(string from, string to, int weight)
        {
            var edge = new Edge(from, to, weight);
            edges.Add(edge);
            if (!directedGraph)
            {
                edges.Add(new Edge(to, from, weight));
            }
        }

        public List<Edge> KruskalMST()
        {
            // 결과집합
            var mst = new List<Edge>();

            // 정점수만큼 분리집합 생성
            DisjointSet djset = new DisjointSet();
            foreach (var vtx in vertices)
            {
                djset.CreateSet(vtx);
            }

            // 가중치 오름차순으로 Edge 정렬
            edges.Sort((elem1, elem2) => elem1.Weight - elem2.Weight);

            // 정렬된 Edge 순으로
            foreach (var edge in edges)
            {
                // 시작정점과 목표정점의 부모정점 검색
                var fromParent = djset.Find(edge.From);
                var toParent = djset.Find(edge.To);

                // 부모정점이 다르면 즉 분리집합이 다르면
                if(fromParent != toParent)
                {
                    // 분리집합 병합
                    djset.Union(fromParent, toParent);
                    // 결과집합 추가
                    mst.Add(edge);
                }
            }

            // 결과집합 리턴
            return mst;
        }
    }
}
