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

        /// <summary>
        /// 재귀적 전위 순회
        /// </summary>
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

        /// <summary>
        /// 중위 전위 순회
        /// </summary>
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

        /// <summary>
        /// 재귀적 후위 순회
        /// </summary>
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

        /// <summary>
        /// 스택을 사용한 전위 순회
        /// </summary>
        public void PreorderIterative()
        {
            if (Root == null) return; // 최상위 노드가 없을 경우 반환

            var stack = new Stack<BinaryTreeNode<T>>(); // 순회를 하기 위한 스택 생성
            stack.Push(Root); // 최상위 노드 푸쉬

            while (stack.Count > 0) // 순회를 하면서 스택에 요소가 없을 때 까지 반복
            {
                BinaryTreeNode<T> node = stack.Pop(); // 가장 마지막에 삽입된 요소 반환

                Console.Write($"{node.Data} "); // 현재노드 출력

                // 전위 순회이므로 오른쪽 노드 부터 스택에 삽입
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                // 왼쪽 노드 스택에 삽입
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }
        
        // <summary>
        /// 스택을 사용한 중위 순회
        /// </summary>
        public void InorderIterative()
        {
            var stack = new Stack<BinaryTreeNode<T>>(); // 순회를 하기 위한 스택 생성
            BinaryTreeNode<T> node = Root; // 최상위 노드 가져오기

            // 최상위 노드를 시작으로 마지막에 있는 자식노드까지 모두 스택에 삽입
            while (node != null)
            {
                stack.Push(node); // 스택에 삽입
                node = node.Left; // 삽입 후 노드 초기화
            }

            while (stack.Count > 0)
            {
                node = stack.Pop(); // 현재노드에 가장 마지막에 있는 자식노드 부터 출력
                Console.Write($"{node.Data} "); // 현재노드 출력
                if (node.Right != null) // 현재노드에 오른쪽 자식노드 검사
                {
                    node = node.Right; // 현재노드에 오른쪽 자식노드 초기화

                    while (node != null) // 현재노드(오른쪽 자식노드)가 null이 아닐 경우
                    {
                        stack.Push(node); // 현재노드를 스택에 저장
                        node = node.Left; // 현재노드는 다시 왼쪽 자식노드로 초기화
                    }
                }
            }
        }

        /// <summary>
        /// 기존 InorderIterative() 메서드에서 
        /// 최좌측(Leftmost) 노드까지 스택에 저장하는 중복 부분을 제거한 최적화 코드
        /// </summary>
        public void InorderIterative2()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while (node != null || stack.Count > 0)
            {
                // Leftmost 노드까지 스택에 저장
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                // 스택에서 노드 가져옴
                node = stack.Pop();

                // Visit
                Console.Write($"{node.Data} ");

                // 오른쪽 노드가 있으면 루프가 돌아서
                // Leftmost 노드까지 스택에 저장
                node = node.Right;
            }
        }

        /// <summary>
        /// 스택을 사용한 후위 순회
        /// </summary>
        public void PostorderIterrative()
        {
            var stack = new Stack<BinaryTreeNode<T>>(); // 순회를 하기 위한 스택 생성
            BinaryTreeNode<T> node = Root; // 최상위 노드 가져옴

            while (node != null)
            {
                if (node.Right != null)
                {
                    stack.Push(node.Right); // 오른쪽 자식노드가 있을 경우 스택에 저장
                }
                stack.Push(node); // 현재노드를 스택에 저장
                node = node.Left; // 왼쪽자식노드를 현재노드에 초기화
            }

            while (stack.Count > 0)
            {
                node = stack.Pop(); // 마지막에 저장된 노드 가져옴

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
                    Console.Write($"{node.Data} ");
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

        public BinaryTreeNode<T> LeastCommonAncestor(BinaryTreeNode<T> root, BinaryTreeNode<T> a, BinaryTreeNode<T> b)
        {
            if (root == null) return null;

            if (root == a || root == b)
            {
                return root;
            }

            BinaryTreeNode<T> left = LeastCommonAncestor(root.Left, a, b);
            BinaryTreeNode<T> right = LeastCommonAncestor(root.Right, a, b);

            if (left != null && right != null)
            {
                return root;
            }
            else
            {
                return (left != null) ? left : right;
            }
        }
    }
}
