using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinarySearchTree.BST<int>();
            bst.Add(6);
            bst.Add(2);
            bst.Add(7);
            bst.Add(1);
            bst.Add(5);
            bst.Add(3);
            bst.Add(4);

            bst.Remove(2);

        }


    }
}
