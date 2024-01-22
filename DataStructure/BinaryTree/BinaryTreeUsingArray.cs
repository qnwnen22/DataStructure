using System;

namespace DataStructure.BinaryTree
{
    public class BinaryTreeUsingArray
    {
        private object[] arr;

        public BinaryTreeUsingArray(int capacity = 15)
        {
            arr = new object[capacity];
        }

        public object Root
        {
            get => arr[0];
            set => arr[0] = value;
        }

        public void SetLeft(int parentIndex, object data)
        {
            int leftIndex = parentIndex * 2 + 1;

            if (arr[parentIndex] == null || leftIndex >= arr.Length)
            {
                throw new Exception();
            }

            arr[leftIndex] = data;
        }

        public void SetRigth(int parentIndex, object data)
        {
            int rigthIndex = parentIndex * 2 + 2;

            if (arr[parentIndex] == null || rigthIndex >= arr.Length)
            {
                throw new Exception();
            }

            arr[rigthIndex] = data;
        }

        public object GetParent(int childIndex)
        {
            if (childIndex == 0) return null;

            int parentIndex = (childIndex - 1) / 2;
            return arr[parentIndex];
        }

        public object GetLeft(int parentIndex)
        {
            int leftIndex = parentIndex * 2 + 1;
            return arr[leftIndex];
        }

        public object GetRigth(int parentIndex)
        {
            int rightIndex = parentIndex * 2 + 2;
            return arr[rightIndex];
        }

        public void PrintTree()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0} ", arr[i] ?? "_");
            }
            Console.WriteLine();
        }
    }
    public class Traversal<T>
    {
        
    }
}
