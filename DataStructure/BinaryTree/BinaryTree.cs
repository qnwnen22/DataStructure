using System;
using System.Collections.Generic;

namespace DataStructure.BinaryTree
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinaryTree(T root)
        {
            this.Root = new BinaryTreeNode<T>(root);
        }

        public void PreorderTraversal()
        {
            PreorderTraversal(this.Root);
        }

        private void PreorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            Console.WriteLine("{0}", node.Data);
            PreorderTraversal(node.Left);
            PreorderTraversal(node.Right);
        }

        public void InorderTraversal()
        {
            InorderTraversal(Root);
        }

        private void InorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            InorderTraversal(node.Left);
            Console.WriteLine("{0}", node.Data);
            InorderTraversal(node.Right);
        }

        public void PostorderTraversal()
        {
            PostorderTraversal(Root);
        }

        private void PostorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            Console.WriteLine("{0}", node.Data);
        }


        public void PreorderIterative()
        {
            if (Root == null) return;

            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                Console.WriteLine(node.Data);

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }
    }
}
