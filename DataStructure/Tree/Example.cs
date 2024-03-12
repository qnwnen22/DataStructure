using System;

namespace DataStructure.Tree
{
    public class Example
    {
        public static void Example1()
        {
            var A = new StaticTreeNode("A");
            var B = new StaticTreeNode("B");
            var C = new StaticTreeNode("C");
            var D = new StaticTreeNode("D");

            A.Links[0] = B;
            A.Links[1] = C;
            A.Links[2] = D;

            B.Links[0] = new StaticTreeNode("E");
            B.Links[1] = new StaticTreeNode("F");

            D.Links[0] = new StaticTreeNode("G");

            foreach (var node in A.Links)
            {
                Console.WriteLine(node.Data);
            }
        }

        public static void Example2()
        {
            // 노드 생성
            var A = new LCRSNode("A");
            var B = new LCRSNode("B");
            var C = new LCRSNode("C");
            var D = new LCRSNode("D");
            var E = new LCRSNode("E");
            var F = new LCRSNode("F");
            var G = new LCRSNode("G");

            A.LeftChild = B; // A 노드에 B 자식노드 연결
            B.RigthSibling = C; // B 노드에 C 형제노드 연결
            C.RigthSibling = D; // C 노드에 D 형제노드 연결
            
            B.LeftChild = E; // B 노드에 E 자식노드 연결
            E.RigthSibling = F; // E 노드에 F 형제노드 연결
            
            D.LeftChild = G; // D 노드에 G 자식노드 연결

            if (A.LeftChild != null)
            {
                LCRSNode tmp = A.LeftChild;
                Console.WriteLine(tmp.Data);

                while (tmp.RigthSibling != null)
                {
                    tmp = tmp.RigthSibling;
                    Console.WriteLine(tmp.Data);
                }
            }

            // 출력 결과
            // B
            // C
            // D
        }

        public static void Example3()
        {
            LCRSTree tree = new LCRSTree("A");
            var A = tree.Root;
            var B = tree.AddChild(A, "B");
            tree.AddChild(A, "C");
            var D = tree.AddBSibling(B, "D");
            tree.AddChild(B, "E");
            tree.AddChild(B, "F");
            tree.AddChild(D, "G");

            tree.PrintIndexTree();
            
            tree.PrintLevelOrder();
        }
    }
}
