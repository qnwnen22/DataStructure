using System;

namespace DataStructure.Queue
{
    public class QueueUsingCircularArray2
    {
        private object[] datas;
        private int front = 0;
        private int rear = 0;

        public QueueUsingCircularArray2(int queueSize = 16)
        {
            datas = new object[queueSize];
        }

        public void Enqueue(object data)
        {
            if ((rear + 1) % datas.Length == front) // 리스트가 가득 찼는지 확인할 수 있는 공식
            {
                throw new Exception("Full");
            }
            else
            {
                datas[rear] = data;
                rear = (rear + 1) % datas.Length; // 다음 Rear 인덱스를 구하는 공식
            }
        }

        public object Dequeue()
        {
            if (front == rear) // 두 값이 일치할 경우 리스트에 데이터가 없음
            {
                throw new Exception("Empty");
            }

            object data = datas[front];
            front = (front + 1) % datas.Length; // 다음 Front 인덱스를 구하는 공식
            return data;
        }
    }
}
