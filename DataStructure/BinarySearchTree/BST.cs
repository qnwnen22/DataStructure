using DataStructure.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.BinarySearchTree
{
    public class BST<T> where T : IComparable<T>
    {
        // Nested Class로 구현
        private class Node<P>
        {
            public P Data { get; set; }
            public Node<P> Left { get; set; }
            public Node<P> Right { get; set; }

            public Node(P data)
            {
                this.Data = data;
            }
        }

        private Node<T> root;

        public void Add(T data)
        {
            if (root == null)
            {
                root = new Node<T>(data);
                return;
            }

            Node<T> node = root;
            while (node != null)
            {
                int cmp = data.CompareTo(node.Data);
                if (cmp == 0)
                {
                    throw new Exception();
                }
                else if (cmp < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node<T>(data);
                        break;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node<T>(data);
                        break;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }
        }
        public bool Search(T data)
        {
            var node = root;

            while (node != null)
            {
                int cmp = data.CompareTo(node.Data);
                if (cmp == 0)
                {
                    return true;
                }
                else if (cmp < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return false;
        }

        public bool SearchRecursive(T data)
        {
            return SearchRecursive(root, data);
        }

        private bool SearchRecursive(Node<T> node, T data)
        {
            if (node == null) return false;

            int cmp = data.CompareTo(node.Data);
            if (cmp == 0)
            {
                return true;
            }

            return SearchRecursive(node.Left, data) || SearchRecursive(node.Right, data);
        }

        public bool Remove(T data)
        {
            Node<T> node = root;
            Node<T> prev = null;

            // 삭제할 노드 검색
            while (node != null)
            {
                int cmp = data.CompareTo(node.Data);
                if (cmp == 0)
                {
                    break;
                }
                else if (cmp < 0)
                {
                    prev = node;
                    node = node.Left;
                }
                else
                {
                    prev = node;
                    node = node.Right;
                }
            }

            if (node == null) return false;

            //삭제 처리
            if (node.Left == null && node.Right == null)
            {
                // (a) 자식노드가 0개인 경우
                if (prev.Left == node)
                {
                    prev.Left = null;
                }
                else
                {
                    prev.Right = null;
                }
                node = null;
            }
            else if (node.Left == null || node.Right == null)
            {
                // (b) 자식노드가 1개인 경우
                var child = (node.Left != null) ? node.Left : node.Right;
                if (prev.Left == node)
                {
                    prev.Left = child;
                }
                else
                {
                    prev.Right = child;
                }
                node = null;
            }
            else
            {
                // (c) 자식노드가 2개인 경우

                // 오른쪽 서브트리에서 min 노드 검색
                Node<T> pre = node;
                Node<T> min = node.Right;
                while (min.Left != null)
                {
                    pre = min;
                    min = min.Left;
                }

                // min 노드 값으로 대치
                node.Data = min.Data;

                // min 노드의 오른쪽 노드 처리
                if (pre.Left == min)
                {
                    pre.Left = min.Right;
                }
                else
                {
                    pre.Right = min.Right;
                }
            }

            return true;
        }

        private void Traversal(Node<T> node, List<T> list)
        {
            if (node == null) return;
            Traversal(node.Left, list);
            list.Add(node.Data);
            Traversal(node.Right, list);
        }

        public List<T> ToSortList()
        {
            var list = new List<T>();
            Traversal(root, list);
            return list;
        }

        private bool FindKthSmallest(Node<T> node, int k, ref int count)
        {
            if (node == null) return false;

            bool found = FindKthSmallest(node.Left, k, ref count);

            if (found) return true;

            count++;
            if (count == k)
            {
                Console.WriteLine(node.Data);
                return true;
            }

            return FindKthSmallest(node.Right, k, ref count);
        }

        public void FindKthSmallest(int k)
        {
            int count = 0;
            FindKthSmallest(root, k, ref count);
        }

        private bool FindKthLargest(Node<T> node, int k, ref int count)
        {
            if (node == null) return false;

            bool fount = FindKthLargest(node.Right, k, ref count);
            if (fount) return true;

            count++;
            if (count == k)
            {
                Console.WriteLine(node.Data);
                return true;
            }

            return FindKthLargest(node.Left, k, ref count);
        }

        public void FindKthLargest(int k)
        {
            int count = 0;
            FindKthLargest(root, k, ref count);
        }

        public void InorderSuccessor(T key)
        {
            Node<T> node = root;
            Node<T> prev = null;

            while (node != null)
            {
                int cmp = node.Data.CompareTo(key);
                if (cmp == 0)
                {
                    if (node.Right == null)
                    {
                        // 부모 노드
                        if (prev != null)
                        {
                            Console.WriteLine(prev.Data);
                        }
                    }
                    else
                    {
                        // 오른쪽 서브트리에서 가장 왼쪽 노드 검색
                        node = node.Right;
                        while (node.Left != null)
                        {
                            node = node.Left;
                        }
                        Console.WriteLine(node.Data);
                    }
                    break;
                }
                else if (cmp > 0)
                {
                    prev = node;
                    node = node.Left;
                }
                else
                {
                    prev = node;
                    node = node.Right;
                }
            }
        }

        // 재귀 방식
        private Node<T> LCA(Node<T> node, T a, T b)
        {
            if (node == null) return null;

            if (a.CompareTo(node.Data) < 0 && b.CompareTo(node.Data) < 0)
            {
                return LCA(node.Left, a, b);
            }
            else if (a.CompareTo(node.Data) > 0 && b.CompareTo(node.Data) > 0)
            {
                return LCA(node.Right, a, b);
            }

            return node;
        }

        public void LeastCommonAncestor(T a, T b)
        {
            Node<T> lca = LCA(root, a, b);

            if (lca != null)
            {
                Console.WriteLine(lca.Data);
            }
        }

        private Node<T> IterativeLCA(Node<T> node, T a, T b)
        {
            while (node != null)
            {
                if (a.CompareTo(node.Data) < 0 && b.CompareTo(node.Data) < 0)
                {
                    node = node.Left;
                }
                else if (a.CompareTo(node.Data) > 0 && b.CompareTo(node.Data) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public static BinaryTreeNode<T> ConvertToBST(BinaryTreeNode<T> root)
        {
            if (root == null) return null;

            // 키를 배열로 저장
            List<T> keys = new List<T>();
            ExtractKeys(root, keys);

            // 소트
            keys.Sort();

            // 순서대로 키 대입
            int index = 0;
            ReplaceKeys(root, keys, ref index);
            return root;
        }
        private static void ExtractKeys(BinaryTreeNode<T> root, List<T> keys)
        {
            if (root == null) return;
            ExtractKeys(root.Left, keys);
            keys.Add(root.Data);
            ExtractKeys(root.Right, keys);
        }

        private static void ReplaceKeys(BinaryTreeNode<T> root, List<T> keys, ref int index)
        {
            if (root == null) return;
            ReplaceKeys(root.Left, keys, ref index);
            root.Data = keys[index];
            index++;
            ReplaceKeys(root.Right, keys, ref index);
        }
    }
}
