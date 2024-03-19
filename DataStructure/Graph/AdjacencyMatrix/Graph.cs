using System;
using System.Collections.Generic;

namespace DataStructure.Graph.AdjacencyMatrix
{
    public class Graph
    {
        // 인접행렬 2차원배열
        private int[,] mat;
        // 정점 레이블 배열
        private List<string> vertexList;

        private int size;
        private bool digraph;

        // 인접행렬 초기화
        public Graph(string[] vertexLabels, bool digraph = false)
        {
            this.vertexList = new List<string>(vertexLabels);
            this.size = vertexList.Count;
            this.mat = new int[size, size];
            this.digraph = digraph;
        }

        // Edge 추가
        public void AddEdge(string from, string to, int weight = 1)
        {
            int iFrom = vertexList.FindIndex(x => x == from);
            int iTo = vertexList.FindIndex(x => x == to);

            AddEdge(iFrom, iTo, weight);
        }

        private void AddEdge(int fromIndex, int toIndex, int weight)
        {
            mat[fromIndex, toIndex] = weight;
            if (!digraph)
            {
                mat[toIndex, fromIndex] = weight;
            }
        }

        // Edge 제거
        public void RemoveEdge(string from, string to)
        {
            int iFrom = vertexList.FindIndex(x => x == from);
            int iTo = vertexList.FindIndex(x => x == to);

            RemoveEdge(iFrom, iTo);
        }

        private void RemoveEdge(int fromIndex, int toIndex)
        {
            mat[fromIndex, toIndex] = 0;
            if (!digraph)
            {
                mat[toIndex, fromIndex] = 0;
            }
        }

        internal void DebugPrintGraph()
        {
            // Matrix 상단
            Console.Write("  ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{vertexList[i]} ");
            }
            Console.WriteLine();

            // Matrix 라인들
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{vertexList[i]} ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{mat[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
