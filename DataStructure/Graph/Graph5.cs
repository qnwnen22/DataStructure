using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class Graph5
    {
        // 인접행렬 2차원배열
        private int[,] mat;
        // 정점 레이블 배열
        private List<string> vertexList;

        private int size;
        private bool digraph;


        public Graph5(string[] vertexLables, bool digraph = false)
        {
            this.vertexList = new List<string>(vertexLables);
            this.size = this.vertexList.Count;
            this.mat = new int[size, size];
            this.digraph = digraph;
        }

    }
}
