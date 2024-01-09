using System;

namespace DataStructure.LinkedList
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> head;

        public void Add(SinglyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                SinglyLinkedListNode<T> current = head;
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void AddAfter(SinglyLinkedListNode<T> currnet, SinglyLinkedListNode<T> newNode)
        {
            if (head == null || currnet == null || newNode == null)
            {
                throw new Exception();
            }

            newNode.Next = currnet.Next;
            currnet.Next = newNode;
        }

        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head)
            {
                head = head.Next;
                removeNode = null;
            }
            else
            {
                SinglyLinkedListNode<T> current = head;

                while (current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    current.Next = removeNode.Next;
                    removeNode = null;
                }
            }
        }

        public SinglyLinkedListNode<T> GetNode(int index)
        {
            SinglyLinkedListNode<T> current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public int Count()
        {
            int cnt = 0;

            SinglyLinkedListNode<T> current = head;
            while (current != null)
            {
                cnt++;
                current = current.Next;
            }

            return cnt;
        }
    }
}
