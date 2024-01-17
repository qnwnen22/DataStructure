using System;

namespace DataStructure.Stack
{
    public class StackUsingLinkedList
    {
        private class Node
        {
            public object Data { get; set; }
            public Node Next { get; set; }
            public Node(object data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node top = null;
        public bool IsEmpty
        {
            get { return top == null; }
        }

        public void Push(object data)
        {
            if (top == null)
            {
                top = new Node(data);
            }
            else
            {
                var node = new Node(data);
                node.Next = top;
                top = node;
            }
        }

        public object Pop()
        {
            if (this.IsEmpty)
            {
                throw new Exception("Empty");
            }

            object data = top.Data;
            top = top.Next;
            return data;
        }

        public object Peek()
        {
            if (this.IsEmpty)
            {
                throw new Exception("Empty");
            }

            return top.Data;
        }
    }
}
