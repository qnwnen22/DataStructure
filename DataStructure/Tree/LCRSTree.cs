using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Tree
{
    public class LCRSTree
    {
        public LCRSNode Root { get; private set; }
        public LCRSTree(object data)
        {
            //this.Data = data;
            this.Root = new LCRSNode(data);
        }

        public LCRSNode AddChild(LCRSNode parent, object data)
        {
            if (parent == null) return null;

            var child = new LCRSNode(data);
            if (parent.LeftChild == null)
            {
                parent.LeftChild = child;
            }
            else
            {
                var node = parent.LeftChild;
                while (node.RigthSibling != null)
                {
                    node = node.RigthSibling;
                }
                node.RigthSibling = child;
            }
            return child;
        }

        public LCRSNode AddBSibling(LCRSNode node, object data)
        {
            if (node == null) return null;

            while (node.RigthSibling != null)
            {
                node = node.RigthSibling;
            }

            var sibling = new LCRSNode(data);
            node.RigthSibling = sibling;

            return sibling;
        }

        public void PrintLevelOrder()
        {
            var q = new Queue<LCRSNode>();
            q.Enqueue(this.Root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                while (node != null)
                {
                    Console.WriteLine($"{node.Data}");

                    if (node.LeftChild != null)
                    {
                        q.Enqueue(node.LeftChild);
                    }

                    node = node.RigthSibling;
                }
            }
        }

        public void PrintIedexTree()
        {
            PrintIndent(this.Root, 1);
        }

        private void PrintIndent(LCRSNode node, int indent)
        {
            if (node == null) return;

            string pad = " ".PadLeft(indent);
            Console.WriteLine($"{pad}-{node.Data}");

            PrintIndent(node.LeftChild, indent + 1);

            PrintIndent(node.RigthSibling, indent);
        }
    }
}
