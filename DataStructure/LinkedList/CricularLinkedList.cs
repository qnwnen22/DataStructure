using System;

namespace DataStructure.LinkedList
{
    public class CricularLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;
        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
            }
            else
            {
                DoublyLinkedListNode<T> tail = head.Prev;

                head.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = head;
            }
        }

        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new Exception();
            }

            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }

        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head && head == head.Next)
            {
                head = null;
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }

            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            if (head == null) return null;

            int count = 0;
            DoublyLinkedListNode<T> current = head;
            while (count < index)
            {
                current = current.Next;
                count++;
                if (current == head)
                {
                    return null;
                }
            }

            return current;
        }

        public int Count()
        {
            if (head == null) return 0;

            int count = 0;
            DoublyLinkedListNode<T> current = head;
            do
            {
                count++;
                current = current.Next;
            }
            while (current != null);

            return count;
        }

        public static bool IsCircular(DoublyLinkedListNode<T> head)
        {
            if (head == null) return true;

            DoublyLinkedListNode<T> current = head;
            while (current != null)
            {
                if (current == head)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsCyclic(SinglyLinkedListNode<int> head)
        {
            SinglyLinkedListNode<int> p1 = head;
            SinglyLinkedListNode<int> p2 = head;

            do
            {
                p1 = p1.Next;
                p2 = p2.Next;
                if (p1 == null || p2 == null || p2.Next == null)
                {
                    return false;
                }
                p2 = p2.Next;
            }
            while (p1 != p2);
            
            return true;
        }

    }
}
