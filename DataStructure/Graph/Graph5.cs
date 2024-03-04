using System;
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

        public void AddEdge(string from, string to, int weight = 1)
        {
            int iFrom = vertexList.FindIndex(s => s == from);
            int iTo = vertexList.FindIndex(s => s == to);
            AddEdge(iFrom, iTo, weight);

        }

        public void AddEdge(int fromIndex, int toInedx, int weight = 1)
        {
            mat[fromIndex, toInedx] = weight;
            if (!digraph)
            {
                mat[toInedx, fromIndex] = weight;
            }
        }

        //Edge 제거
        public void RemoveEdge(string from, string to)
        {
            int iFrom = vertexList.FindIndex(s => s == from);
            int iTo = vertexList.FindIndex(s => s == to);
            RemoveEdge(iFrom, iTo);
        }

        public void RemoveEdge(int fromIndex, int toIndex)
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
            Console.WriteLine("  ");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{vertexList[i]} ");
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
