using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList.CricularLinkedList<int>();
            list.Add(new LinkedList.DoublyLinkedListNode<int>(1));
            var two = new LinkedList.DoublyLinkedListNode<int>(2);
            list.Add(two);
            list.Add(new LinkedList.DoublyLinkedListNode<int>(3));
            list.Remove(two);

            //LinkedList.Example.Example1();
            //LinkedList.Example.Example2();
            //LinkedList.Example.Example3();

            //Tree.Example.Example1();
            //Tree.Example.Example2();
            //Tree.Example.Example3();

            //BinaryTree.Example.Example1();
            //BinaryTree.Example.Example2();
            //BinaryTree.Example.Example3();

            //BinarySearchTree.Example.Example1();
            //BinarySearchTree.Example.Example2();
            //BinarySearchTree.Example.Example3();

            //Heap.Exmaple.Example1();

            //Trie.Example.Example1();
            //Trie.Example.Example2();
            //Trie.Example.Example3();

            //Graph.Example.Example1();
            //Graph.Example.Example2();
            //Graph.Example.Example3();

            //Graph.Example.Example4();
            // Graph.Example.Example5();
            //Graph.Example.Example6();
            //Graph.Example.Example7();
            //Graph.Example.Example8();
            Graph.Example.Example9();
        }
    }
}
