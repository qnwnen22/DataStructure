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
            var bt = new BinaryTreeUsingArray(7);
            bt.Root = "A";
            bt.SetLeft(0, "B");
            bt.SetRigth(0, "C");
            bt.SetLeft(1, "D");
            bt.SetLeft(2, "F");

            bt.PrintTree();

            var data = bt.GetParent(5);
            System.Console.WriteLine(data);

            data = bt.GetLeft(2);
            System.Console.WriteLine(data); ;
        }
    }
}
