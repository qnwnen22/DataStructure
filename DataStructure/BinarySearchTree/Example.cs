using DataStructure.BinaryTree;
using System;
using System.Collections.Generic;

namespace DataStructure.BinarySearchTree
{
    public class Example
    {
        private static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static void Example1()
        {
            var bst = new BST<int>();
            bst.Add(6);
            bst.Add(7);
            bst.Add(2);
            bst.Add(1);
            bst.Add(5);
            bst.Add(3);
            bst.Add(4);

            bool found = bst.Search(4);
            Console.WriteLine(found);

            // 출력: 1 2 3 4 5 6 7
            List<int> list = bst.ToSortList();
            PrintList(list);
            // 2 삭제
            bst.Remove(2);
            // 출력: 1 3 4 5 6 7
            PrintList(list);
        }

        public static void Example2()
        {
            var bst = new BST<int>();
            bst.Add(6);
            bst.Add(7);
            bst.Add(2);
            bst.Add(1);
            bst.Add(5);
            bst.Add(3);
            bst.Add(4);

            // 출력: 2
            bst.LeastCommonAncestor(1, 4);
        }

        public static void Example3()
        {
            var root = new BinaryTreeNode<int>(3);
            root.Left = new BinaryTreeNode<int>(5);
            root.Left.Left = new BinaryTreeNode<int>(7);
            root.Left.Right = new BinaryTreeNode<int>(6);
            root.Right = new BinaryTreeNode<int>(9);
            root.Right.Right = new BinaryTreeNode<int>(8);

            BinaryTreeNode<int> tree = BST<int>.ConvertToBST(root);
        }
    }
}
