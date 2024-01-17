using System;

namespace DataStructure.Queue
{
    public class QueueUsingCircularArray2
    {
        private object[] a;
        private int front = 0;
        private int rear = 0;

        public QueueUsingCircularArray2(int queueSize = 16)
        {
            a = new object[queueSize];
        }

        public void Enqueue(object data)
        {
            if ((rear + 1) % a.Length == front) // Full
            {
                throw new Exception("Full");
            }
            else
            {
                a[rear] = data;
                rear = (rear + 1) % a.Length;
            }
        }

        public object Dequeue()
        {
            if (front == rear) // Empty
            {
                throw new Exception("Empty");
            }

            object data = a[front];
            front = (front + 1) % a.Length;
            return data;
        }
    }
}
