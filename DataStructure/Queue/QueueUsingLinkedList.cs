using System;

namespace DataStructure.Queue
{
    public class QueueUsingLinkedList
    {
        private Node head = null;
        private Node tail = null;

        public void Enqueue(object data)
        {
            // Queue가 비어 있는 경우
            if (head == null)
            {
                head = new Node(data);
                tail = head;
            }
            else // 비어 있는 경우
            {
                tail.Next = new Node(data);
                tail = tail.Next;
            }
        }

        public object Dequeue()
        {
            if (head == null)
            {
                throw new Exception("Empty");
            }

            object data = head.Data;

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
            }

            return data;
        }
    }
}
