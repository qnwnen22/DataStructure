using System;

namespace DataStructure.Stack
{
    public class StackUsingArray
    {
        private object[] datas; // 데이터 리스트
        private int top; // 마지막 인덱스
        public bool IsEmpty
        {
            get { return top == -1; }
        }

        public int Capacity
        {
            get { return datas.Length; }
        }

        public StackUsingArray(int capacity = 16)
        {
            datas = new object[capacity];
            top = -1;
        }

        /// <summary>
        /// 리스트에 데이터 삽입하는 메서드
        /// </summary>
        /// <param name="data">삽입할 데이터</param>
        public void Push(object data)
        {
            if (top == datas.Length - 1) // 데이터가 리스트안에 가득 차있을 경우
            {
                // throw 하거나 아래처럼 배열 확장
                ResizeStack();
            }

            datas[++top] = data; // 데이터 삽입
        }

        /// <summary>
        /// 리스트의 크기를 동적으로 확장하는 메서드
        /// </summary>
        private void ResizeStack()
        {
            int capacity = 2 * datas.Length; // 기존 리스트의 크기의 2배만큼 설정
            object[] tempArray = new object[capacity]; // 새로 할당할 리스트 생성
            System.Array.Copy(datas, tempArray, datas.Length); // 데이터 요소 복사
            datas = tempArray; // 필드에 새로 생성한 리스트 초기화
        }

        /// <summary>
        /// 리스트에서 가장 마지막에 삽입된 데이터를 꺼내오는 메서드
        /// </summary>
        /// <returns>리스트 마지막 요소</returns>
        public object Pop()
        {
            if (this.IsEmpty)
            {
                throw new Exception("Empty");
            }
            return datas[top--]; // 데이터를 반환하고 마지막 인덱스를 감소
        }

        /// <summary>
        /// 리스트에서 가장 마지막에 삽입된 데이터를 가져오는 메서드
        /// </summary>
        /// <returns>리스트 마지막 요소</returns>
        public object Peek()
        {
            if (this.IsEmpty)
            {
                throw new Exception("Empty");
            }
            return datas[top]; // 데이터를 반환하지만 마지막 인덱스를 감소하지 않음
        }
    }
}
