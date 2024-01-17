using System;

namespace DataStructure.Queue
{
    public class QueueUsingCircularArray
    {
        private object[] a;
        private int front;
        private int rear;

        public QueueUsingCircularArray(int queueSize = 16)
        {
            a = new object[queueSize];
            front = -1;
            rear = -1;
        }

        public void Enqueue(object data)
        {
            if ((rear + 1) % a.Length == front)
            {
                throw new Exception();
            }
            else
            {
                if (front == -1)
                {
                    front++;
                }

                rear = (rear + 1) % a.Length;
                a[rear] = data;
            }
        }

        public object Dequeue()
        {
            if (front == -1 && rear == -1)
            {
                throw new Exception();
            }
            else
            {
                object data = a[front];

                if (front == rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front = (front + 1) % a.Length;
                }

                return data;
            }
        }
    }
}
