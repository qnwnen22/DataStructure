using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var A = new LCRSNode("A");
            var B = new LCRSNode("B");
            var C = new LCRSNode("C");
            var D = new LCRSNode("D");
            var E = new LCRSNode("E");
            var F = new LCRSNode("F");
            var G = new LCRSNode("G");

            A.LeftChild = B;
            B.RigthSibling = C;
            C.RigthSibling = D;
            B.LeftChild = E;
            E.RigthSibling = F;
            D.LeftChild = G;

            if (A.LeftChild != null)
            {
                var tmp = A.LeftChild;
                Console.WriteLine(tmp.Data);

                while (tmp.RigthSibling != null)
                {
                    tmp = tmp.RigthSibling;
                    Console.WriteLine(tmp.Data);
                }
            }
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

            tree.PrintIedexTree();
            
            tree.PrintLevelOrder();
        }
    }
}
