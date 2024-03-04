using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class Example
    {
        public static void Example1()
        {
            var gr = new Graph<string>();
            Node1<string> seoul = gr.AddVertex("서울");
            Node1<string> daejun = gr.AddVertex("대전");
            Node1<string> daeku = gr.AddVertex("대구");
            Node1<string> pusan = gr.AddVertex("부산");
            Node1<string> kangrung = gr.AddVertex("강릉");

            gr.AddEdge(seoul, daejun, 6);
            gr.AddEdge(seoul, daeku, 7);
            gr.AddEdge(seoul, kangrung, 10);
            gr.AddEdge(daejun, pusan, 7);
            gr.AddEdge(daeku, pusan, 3);
            gr.AddEdge(kangrung, daeku, 4);

            gr.DebugPrintGraph();
        }

        public static void Example2()
        {
            var gr = new Graph3();
            gr.AddVertex("A");
            gr.AddVertex("B");
            gr.AddVertex("C");
            gr.AddVertex("D");
            gr.AddEdge("A", "B", 5);
            gr.AddEdge("A", "D", 9);
            gr.AddEdge("B", "D", 6);
            gr.AddEdge("D", "C", 7);

            gr.DebugPrintGraph();
        }

        public static void Example3()
        {
            var gr = new Graph4();
            gr.AddVertex("A");
            gr.AddVertex("B");
            gr.AddVertex("C");
            gr.AddVertex("D");
            gr.AddEdge("A", "B", 5);
            gr.AddEdge("A", "D", 9);
            gr.AddEdge("B", "D", 6);
            gr.AddEdge("D", "C", 7);

            gr.DebugPrintGraph();
        }

        public static void Example4()
        {
            string[] vertices = { "A", "B", "C", "D" };

            Graph5 gr = new Graph5(vertices);
            gr.AddEdge("A", "B");
            gr.AddEdge("B", "D");
            gr.AddEdge("A", "D");
            gr.AddEdge("C", "D");

            gr.DebugPrintGraph();
        }

        public static void Example5()
        {
            var gr = new Graph<string>();
            var A = gr.AddVertex("A");
            var B = gr.AddVertex("B");
            var C = gr.AddVertex("C");
            var D = gr.AddVertex("D");
            var E = gr.AddVertex("E");
            var F = gr.AddVertex("F");
            var G = gr.AddVertex("G");

            // 비연결그래프 - 부분그래프 X-Y
            var X = gr.AddVertex("X");
            var Y = gr.AddVertex("Y");

            gr.AddEdge(A, B);
            gr.AddEdge(A, D);
            gr.AddEdge(A, E);
            gr.AddEdge(B, C);
            gr.AddEdge(E, F);
            gr.AddEdge(E, G);
            gr.AddEdge(E, G);
            gr.AddEdge(X, Y);

            gr.DFS();

            // 실행결과 : 
            // A B C D E F G
            // X Y 
        }

        public static void Example6()
        {
            var gr = new Graph<string>();
            var A = gr.AddVertex("A");
            var B = gr.AddVertex("B");
            var C = gr.AddVertex("C");
            var D = gr.AddVertex("D");
            var E = gr.AddVertex("E");
            var F = gr.AddVertex("F");

            gr.AddEdge(A, B);
            gr.AddEdge(A, D);
            gr.AddEdge(B, C);
            gr.AddEdge(C, D);
            gr.AddEdge(C, E);
            gr.AddEdge(C, F);
            gr.AddEdge(D, F);

            Stack<Node1<string>> result = gr.TopologicalSort();
            foreach (Node1<string> node in result)
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
            var g = new GraphV3();
            var a = g.AddVertex("0");
            g.AddVertex("1");
            g.AddVertex("2");
            g.AddVertex("3");
            g.AddVertex("4");
            g.AddVertex("5");
            g.AddVertex("6");
            g.AddEdge("0", "1", 7);
            g.AddEdge("0", "4", 3);
            g.AddEdge("0", "5", 10);
            g.AddEdge("1", "5", 6);
            g.AddEdge("1", "2", 4);
            g.AddEdge("1", "3", 10);
            g.AddEdge("2", "3", 2);
            g.AddEdge("3", "5", 9);
            g.AddEdge("4", "1", 2);
            g.AddEdge("4", "3", 11);
            g.AddEdge("4", "6", 5);
            g.AddEdge("6", "3", 4);

            g.Dijkstra(a);

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
