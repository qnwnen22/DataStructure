using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class Example
    {
        /// <summary>
        /// 동적배열을 활용한 그래프 사용 예제
        /// </summary>
        public static void Example1()
        {
            var graph = new UsingDynamicArray.Graph<string>();

            var seoul = graph.AddVertex("서울");
            var daejun = graph.AddVertex("대전");
            var daeku = graph.AddVertex("대구");
            var pusan = graph.AddVertex("부산");
            var kangrung = graph.AddVertex("강릉");

            graph.AddEdge(seoul, daejun, 6);
            graph.AddEdge(seoul, daeku, 7);
            graph.AddEdge(seoul, kangrung, 10);
            graph.AddEdge(daejun, pusan, 7);
            graph.AddEdge(daeku, pusan, 3);
            graph.AddEdge(kangrung, daeku, 4);

            graph.DebugPrintGraph();
        }

        /// <summary>
        /// 해시테이블을 활용한 그래프 사용 예제
        /// </summary>
        public static void Example2()
        {
            var graph = new UsingHashtable.Graph();

            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");

            graph.AddEdge("A", "B", 5);
            graph.AddEdge("A", "D", 9);
            graph.AddEdge("B", "D", 6);
            graph.AddEdge("D", "C", 7);

            graph.DebugPrintGraph();
        }

        /// <summary>
        /// 링크드리스트를 활용한 그래프 사용 예제
        /// </summary>
        public static void Example3()
        {
            var graph = new UsingLinkedList.Graph();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");

            graph.AddEdge("A", "B", 5);
            graph.AddEdge("A", "D", 9);
            graph.AddEdge("B", "D", 6);
            graph.AddEdge("D", "C", 7);

            graph.DebugPrintGraph();
        }

        /// <summary>
        /// 인접행렬 그래프 사용 예제
        /// </summary>
        public static void Example4()
        {
            string[] vertices = { "A", "B", "C", "D" };

            var graph = new AdjacencyMatrix.Graph(vertices);

            graph.AddEdge("A", "B");
            graph.AddEdge("B", "D");
            graph.AddEdge("A", "D");
            graph.AddEdge("C", "D");

            graph.DebugPrintGraph();
        }

        /// <summary>
        /// 그래프 탐색 예제(동적배열 그래프)
        /// </summary>
        public static void Example5()
        {
            var graph = new UsingDynamicArray.Graph<string>();
            var A = graph.AddVertex("A");
            var B = graph.AddVertex("B");
            var C = graph.AddVertex("C");
            var D = graph.AddVertex("D");
            var E = graph.AddVertex("E");
            var F = graph.AddVertex("F");
            var G = graph.AddVertex("G");

            // 비연결그래프 - 부분그래프 X-Y
            var X = graph.AddVertex("X");
            var Y = graph.AddVertex("Y");

            graph.AddEdge(A, B);
            graph.AddEdge(A, D);
            graph.AddEdge(A, E);
            graph.AddEdge(B, C);
            graph.AddEdge(E, F);
            graph.AddEdge(E, G);
            graph.AddEdge(E, G);
            graph.AddEdge(X, Y);

            Console.WriteLine("DFS : ");
            graph.DFS();
            Console.WriteLine();

            Console.WriteLine("DFSIterative : ");
            graph.DFSIterative();
            Console.WriteLine();

            Console.WriteLine("BFS : ");
            graph.BFS();
            Console.WriteLine();
        }



        public static void Example6()
        {
            var graph = new UsingDynamicArray.Graph<string>(true);
            var A = graph.AddVertex("A");
            var B = graph.AddVertex("B");
            var C = graph.AddVertex("C");
            var D = graph.AddVertex("D");
            var E = graph.AddVertex("E");
            var F = graph.AddVertex("F");

            graph.AddEdge(A, B);
            graph.AddEdge(A, D);
            graph.AddEdge(B, C);
            graph.AddEdge(C, D);
            graph.AddEdge(C, E);
            graph.AddEdge(C, F);
            graph.AddEdge(D, F);

            var result = graph.TopologicalSort();
            foreach (var node in result)
            {
                Console.Write("{0} ", node.Data);
            }
            Console.WriteLine();
            // 결과 : A B C D E F
        }

        public static void Example7()
        {
            string[] verices = { "A", "B", "C", "D", "E", "F" };
            var g = new GraphV2(verices);
            g.AddEdge("A", "B", 2);
            g.AddEdge("A", "C", 3);
            g.AddEdge("B", "C", 5);
            g.AddEdge("B", "D", 3);
            g.AddEdge("B", "E", 4);
            g.AddEdge("C", "E", 4);
            g.AddEdge("D", "E", 2);
            g.AddEdge("D", "F", 3);
            g.AddEdge("E", "F", 5);

            var mst = g.KruskalMST();
            foreach (var m in mst)
            {
                Console.WriteLine($"{m.From}-{m.To} {m.Weight}");
            }

            // (결과출력)
            //  A-B 2
            //  E-D 2
            //  A-C 3
            //  F-D 3
            //  B-D 3
        }

        public static void Example8()
        {
            var g = new GraphV3();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");
            g.AddVertex("F");

            g.AddEdge("A", "B", 2);
            g.AddEdge("A", "C", 3);
            g.AddEdge("B", "C", 5);
            g.AddEdge("B", "D", 3);
            g.AddEdge("B", "E", 4);
            g.AddEdge("C", "E", 4);
            g.AddEdge("D", "E", 2);
            g.AddEdge("D", "F", 3);
            g.AddEdge("E", "F", 5);

            g.PrimMST();

            // (결과출력)
            // A - B 2
            // A - C 3
            // B - D 3
            // D - E 2
            // D - F 3
        }

        public static void Example9()
        {
            var graph = new GraphV3();

            var startNode = graph.AddVertex("0");
            graph.AddVertex("1");
            graph.AddVertex("2");
            graph.AddVertex("3");
            graph.AddVertex("4");
            graph.AddVertex("5");
            graph.AddVertex("6");

            graph.AddEdge("0", "1", 7);
            graph.AddEdge("0", "4", 3);
            graph.AddEdge("0", "5", 10);
            graph.AddEdge("1", "5", 6);
            graph.AddEdge("1", "2", 4);
            graph.AddEdge("1", "3", 10);
            graph.AddEdge("2", "3", 2);
            graph.AddEdge("3", "5", 9);
            graph.AddEdge("4", "1", 2);
            graph.AddEdge("4", "3", 11);
            graph.AddEdge("4", "6", 5);
            graph.AddEdge("6", "3", 4);

            graph.Dijkstra(startNode);

            // (결과출력)
            // 정점: 가중치 / 이전노드
            // 0   : 0 / 0
            // 1   : 5 / 4
            // 2   : 9 / 1
            // 3   : 11 / 2
            // 4   : 3 / 0
            // 5   : 10 / 0
            // 6   : 8 / 4
        }
    }
}
