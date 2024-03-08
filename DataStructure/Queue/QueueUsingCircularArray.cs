using System;

namespace DataStructure.Queue
{
    public class QueueUsingCircularArray
    {
        // 단순화를 위해 object 데이타 타입 사용
        private object[] datas;
        private int front;
        private int rear;

        public QueueUsingCircularArray(int queueSize = 16) // 기본 Queue 크기는 16
        {
            datas = new object[queueSize]; // 배열 생성
            front = -1;
            rear = -1;
        }

        /// <summary>
        /// 데이터 삽입
        /// </summary>
        /// <param name="data">데이터</param>
        public void Enqueue(object data)
        {
            int cal = (rear + 1) % datas.Length;
            if (cal == front) // 배열의 크기를 오버
            {
                throw new Exception();
            }
            else
            {
                if (front == -1) // 리스트에 데이터가 없는 경우 (처음 추가할 경우)
                {
                    front++; // front를 0으로 초기화
                }

                rear = (rear + 1) % datas.Length; // 데이터를 추가할 때 Rear 인덱스를 구하는 공식
                datas[rear] = data;
            }
        }

        /// <summary>
        /// 데이터 출력
        /// </summary>
        /// <returns></returns>
        public object Dequeue()
        {
            if (front == -1 && rear == -1) // 출력한 데이터가 없음
            {
                throw new Exception();
            }
            else
            {
                object data = datas[front]; // 데이터 가져오기

                if (front == rear) // 값이 일치할 경우 데이터가 없음을 의미
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front = (front + 1) % datas.Length; // 데이터를 가져올 때 Front 인덱스를 구한느 공식
                }

                return data;
            }
        }
    }
}
