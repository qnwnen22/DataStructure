using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.BTree
{
    public class BTreeNode<T> where T : IComparable<T>
    {
        public List<T> Keys { get; private set; }
        public List<BTreeNode<T>> Children { get; private set; }
        public bool IsLeaf { get { return Children.Count == 0; } }

        public BTreeNode()
        {
            Keys = new List<T>();
            Children = new List<BTreeNode<T>>();
        }
    }
}
