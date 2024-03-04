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

        
    }
}
