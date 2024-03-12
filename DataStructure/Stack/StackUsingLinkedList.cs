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

        private Node top = null; // 최상위 노드
        public bool IsEmpty
        {
            get { return top == null; }
        }

        /// <summary>
        /// 리스트에 새 노드 삽입
        /// </summary>
        /// <param name="data">데이터</param>
        public void Push(object data)
        {
            if (top == null) // 최상위 노드가 없을 경우
            {
                top = new Node(data); // 새 노드 생성 후 초기화
            }
            else
            {
                var node = new Node(data); // 새 노드 생성
                node.Next = top; // 새 노드와 최상위 노드 연결
                top = node; // 최상위 노드를 새 노드로 초기화
            }
        }

        /// <summary>
        /// 리스트에 최상위 노드를 반환 후 최상위 노드 초기화
        /// </summary>
        /// <returns>최상위 노드</returns>
        public object Pop()
        {
            if (this.IsEmpty)
            {
                throw new Exception("Empty");
            }

            object data = top.Data;
            top = top.Next; // 최상위 노드 변경
            return data;
        }

        /// <summary>
        /// 리스트의 최상위 노드를 반환 후 최상위 노드는 변경되지 않음
        /// </summary>
        /// <returns></returns>
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
