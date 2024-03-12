using System;

namespace DataStructure.BTree
{
    public class BTree<T> where T : IComparable<T>
    {
        private int _minDegree;
        private BTreeNode<T> _root;

        public BTree(int minDegree)
        {
            _minDegree = minDegree;
            _root = new BTreeNode<T>();
        }

        public void Insert(T key)
        {
            if (_root.Keys.Count == (2 * _minDegree) - 1)
            {
                var newRoot = new BTreeNode<T>();
                newRoot.Children.Add(_root);
                SplitChild(newRoot, 0);
                _root = newRoot;
            }
            InsertNonFull(_root, key);
        }

        public void Print()
        {
            PrintTree(_root);
        }

        private void InsertNonFull(BTreeNode<T> node, T key)
        {
            int i = node.Keys.Count - 1;
            if (node.IsLeaf)
            {
                while (i >= 0 && key.CompareTo(node.Keys[i]) < 0)
                {
                    i--;
                }
                node.Keys.Insert(i + 1, key);
            }
            else
            {
                while (i >= 0 && key.CompareTo(node.Keys[i]) < 0)
                {
                    i--;
                }
                i++;
                if (node.Children[i].Keys.Count == (2 * _minDegree) - 1)
                {
                    SplitChild(node, i);
                    if (key.CompareTo(node.Keys[i]) > 0)
                    {
                        i++;
                    }
                }
                InsertNonFull(node.Children[i], key);
            }
        }

        private void PrintTree(BTreeNode<T> node)
        {
            if (node == null)
                return;

            for (int i = 0; i < node.Keys.Count; i++)
            {
                Console.Write($"{node.Keys[i]} ");
            }
            Console.WriteLine();

            if (!node.IsLeaf)
            {
                for (int i = 0; i < node.Children.Count; i++)
                {
                    PrintTree(node.Children[i]);
                }
            }
        }

        private void SplitChild(BTreeNode<T> parentNode, int childIndex)
        {
            var nodeToSplit = parentNode.Children[childIndex];
            var newNode = new BTreeNode<T>();

            parentNode.Keys.Insert(childIndex, nodeToSplit.Keys[_minDegree - 1]);

            newNode.Keys.AddRange(nodeToSplit.Keys.GetRange(_minDegree, _minDegree - 1));
            nodeToSplit.Keys.RemoveRange(_minDegree - 1, _minDegree);

            if (!nodeToSplit.IsLeaf)
            {
                newNode.Children.AddRange(nodeToSplit.Children.GetRange(_minDegree, _minDegree));
                nodeToSplit.Children.RemoveRange(_minDegree, _minDegree);
            }

            parentNode.Children.Insert(childIndex + 1, newNode);
        }
    }
}
