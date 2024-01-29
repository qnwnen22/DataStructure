using System;
using System.Linq;

namespace DataStructure.BinaryTree
{
    public class Node
    {
        public string Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(string data)
        {
            this.Data = data;
        }
    }

    public class ExpressionTree
    {
        public Node Root { get; set; }
        private Node Build(string[] tokens, ref int index)
        {
            Node node = new Node(tokens[index]);

            if (tokens[index] == "+" || tokens[index] == "-" || tokens[index] == "*" || tokens[index] == "/")
            {
                --index;
                node.Right = Build(tokens, ref index);
                --index;
                node.Left = Build(tokens, ref index);
            }

            return node;
        }

        public void Build(string[] tokens)
        {
            int index = tokens.Length - 1;
            Root = Build(tokens, ref index);
        }

        public decimal Evaluate(Node root)
        {
            if (root == null) return 0;

            decimal left = Evaluate(root.Left);
            decimal right = Evaluate(root.Right);

            if (root.Data == "+")
            {
                return left + right;
            }
            else if (root.Data == "-")
            {
                return left - right;
            }
            else if (root.Data == "*")
            {
                return left * right;
            }
            else if (root.Data == "/")
            {
                return left / right;
            }

            return decimal.Parse(root.Data);
        }

        public void Inorder(Node node)
        {
            if (node == null) return;

            if (IsOperator(node.Data))
            {
                Console.Write("(");
            }

            Inorder(node.Left);
            Console.Write($"{node.Data} ");
            Inorder(node.Right);

            if (IsOperator(node.Data))
            {
                Console.Write(")");
            }
        }

        public void Postorder(Node node)
        {
            if (node == null) return;

            Postorder(node.Left);
            Postorder(node.Right);
            Console.WriteLine($"{node.Data} ");
        }

        private string[] op = { "+", "-", "*", "/" };

        private bool IsOperator(string token)
        {
            return op.Contains(token);
        }
    }


}
