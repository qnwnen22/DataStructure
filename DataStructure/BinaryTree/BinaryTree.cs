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

        public void InorderIterative()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while (node != null)
            {
                stack.Push(node);
                node = node.Left;
            }

            while (stack.Count > 0)
            {
                node = stack.Pop();

                Console.WriteLine(node.Data);

                if (node.Right != null)
                {
                    node = node.Right;

                    while (node != null)
                    {
                        stack.Push(node);
                        node = node.Left;
                    }
                }
            }
        }

        public void InorderIterative2()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();

                Console.WriteLine(node.Data);

                node = node.Right;
            }
        }

        public void PostorderIterrative()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while (node != null)
            {
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                stack.Push(node);
                node = node.Left;
            }

            while (stack.Count > 0)
            {
                node = stack.Pop();

                if (node.Right != null && stack.Count > 0 && node.Right == stack.Peek())
                {
                    var right = stack.Pop();
                    stack.Push(node);
                    node = right;

                    while (node != null)
                    {
                        if (node.Right != null)
                        {
                            stack.Push(node.Right);
                        }

                        stack.Push(node);
                        node = node.Left;
                    }
                }
                else
                {
                    Console.WriteLine(node.Data);
                }
            }
        }

        public void PostorderIterrative2()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();

                if (node.Right != null && stack.Count > 0 && node.Right == stack.Peek())
                {
                    var right = stack.Pop();
                    stack.Push(node);
                    node = right;
                }
                else
                {
                    Console.WriteLine(node.Data);
                    node = null;
                }
            }
        }

        public void LevelorderTraversal()
        {
            var q = new Queue<BinaryTreeNode<T>>();

            q.Enqueue(this.Root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                Console.WriteLine("{0}", node.Data);

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }

        public void LevelorderNewLine()
        {
            var q = new Queue<BinaryTreeNode<T>>();

            q.Enqueue(this.Root);
            q.Enqueue(null);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node == null)
                {
                    Console.WriteLine();
                    if (q.Count > 0) q.Enqueue(null);
                    continue;
                }

                Console.WriteLine("{0}", node.Data);

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }

        public int GetMaxDeplth(BinaryTreeNode<T> node)
        {
            if (node == null) return -1;

            return 1 + Math.Max(GetMaxDeplth(node.Left), GetMaxDeplth(node.Right));
        }

        public int Count(BinaryTreeNode<T> node)
        {
            if (node == null) return 0;

            return 1 + Count(node.Left) + Count(node.Right);
        }

        public bool FindTreePath(BinaryTreeNode<T> root, BinaryTreeNode<T> target, List<BinaryTreeNode<T>> path)
        {
            if (root == null) return false;

            path.Add(root);

            if (root == target)
            {
                return true;
            }
            
            if (FindTreePath(root.Left, target, path) || FindTreePath(root.Right, target, path))
            {
                return true;
            }

            path.RemoveAt(path.Count - 1);
            return false;
        }
    }
}
