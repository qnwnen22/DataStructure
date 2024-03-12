using System;
using System.Collections.Generic;

namespace DataStructure.BinaryTree
{
    public class Example
    {
        public static void Example1()
        {
            var bt = new BinaryTree<int>(1);

            bt.Root.Left = new BinaryTreeNode<int>(2);
            bt.Root.Right = new BinaryTreeNode<int>(3);
            bt.Root.Left.Left = new BinaryTreeNode<int>(4);

            bt.PreorderTraversal();
        }

        public static void Example2()
        {
            // 샘플 이진 트리 구성    
            //     A    
            //   B   C    
            // D    F    
            var bt = new BinaryTreeUsingArray(7);
            bt.Root = "A";
            bt.SetLeft(0, "B");
            bt.SetRigth(0, "C");
            bt.SetLeft(1, "D");
            bt.SetLeft(2, "F");

            bt.PrintTree();
            // 출력 결과
            // A B C D _ F _

            var data = bt.GetParent(5);
            Console.WriteLine(data);
            // 출력 결과
            // C

            data = bt.GetLeft(2);
            Console.WriteLine(data);
            // 출력 결과
            // F
        }

        public static void Example3()
        {
            var postfix = "10 4 / 3 5 + +".Split(' ');

            var et = new ExpressionTree();
            et.Build(postfix);

            Console.Write("Inorder: ");
            et.Inorder(et.Root);
            Console.WriteLine();

            Console.Write("Postorder: ");
            et.Postorder(et.Root);
            Console.WriteLine();

            var result = et.Evaluate(et.Root);
            Console.WriteLine($"Result: {result}");
        }

        public static void Example4()
        {
            var path1 = new List<BinaryTreeNode<char>>();
            var path2 = new List<BinaryTreeNode<char>>();


        }


    }
}
