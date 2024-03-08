using System;

namespace DataStructure.Queue
{
    public class QueueUsingCircularArray3
    {
        private object[] datas;
        private int front = 0;
        private int rear = 0;

        public int Count { get; private set; } = 0;

        public QueueUsingCircularArray3(int queueSize = 16)
        {
            datas = new object[queueSize];
        }

        public void Enqueue(object data)
        {
            if (Count == datas.Length)
            {
                throw new Exception("Full");
            }

            datas[rear] = data; // 데이터 삽입
            rear = (rear + 1) % datas.Length; // Rear에 다음 인덱스 값을 할당
            Count++; // 카운트 증가
        }

        public object Dequeue()
        {
            if (Count == 0)
            {
                throw new Exception("Empty");
            }

            object data = datas[front]; // 데이터 출력
            front = (front + 1) % datas.Length; // Front에 다음 인덱스를 할당
            Count--; // 카운트 감소
            return data;
        }
    }
}
