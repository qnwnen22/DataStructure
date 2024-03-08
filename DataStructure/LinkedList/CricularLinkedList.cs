using System;

namespace DataStructure.LinkedList
{
    public class CricularLinkedList<T>
    {
        private DoublyLinkedListNode<T> head; // 최상위 노드

        /// <summary>
        /// 리스트에 노드 추가
        /// </summary>
        /// <param name="newNode">추가할 노드</param>
        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null) // 최상위 노드가 비어 있을 경우
            {
                head = newNode; // 최상위 노드에 새 노드를 초기화

                // 노드가 하나밖에 없으므로 이전(Prev)과 다음(Next)에 자기 자신을 초기화
                head.Next = head;
                head.Prev = head;
            }
            else // 비어 있지 않을 경우
            {
                DoublyLinkedListNode<T> tail = head.Prev;
                // 그림으로 이해
                // 1. [head], [newNode]
                head.Prev = newNode; // 2. [newNode]=>[head], [newNode]
                tail.Next = newNode; // 3. [newNode]=>[head]<=[newNode]
                newNode.Prev = tail; // 4. [newNode]=>[head]<=>[newNode]
                newNode.Next = head; // 5. [newNode]<=>[head]<=>[newNode]
                // 6. [head][newNode][head][newNode]...
            }
        }

        /// <summary>
        /// 현재 노드와 다음 노드 사이에 새로운 노드를 추가
        /// </summary>
        /// <param name="current">다음 노드 사이에 추가할 현재 노드</param>
        /// <param name="newNode">추가할 노드</param>
        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null) // 예외처리
            {
                throw new Exception();
            }

            // 그림으로 이해
            // 1. [current], [newNode]
            newNode.Next = current.Next; // 2. [current], [newNode]<=[current.Next]
            current.Next.Prev = newNode; // 3. [current], [newNode]<=>[current.Next]
            newNode.Prev = current; // 4. [current]=>[newNode]<=>[current.Next]
            current.Next = newNode; // 5. [current]<=>[newNode]<=>[current.Next]
            // 6.[current][newNode][current.Next]
        }

        /// <summary>
        /// 리스트안에 특정 노드를 제거
        /// </summary>
        /// <param name="removeNode">제거할 노드</param>
        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null) // 최상위 노드나 제거할 노드가 null일 경우 연산을 마침
            {
                return;
            }

            if (removeNode == head && head == head.Next) // 제거할 노드가 최상위 노드이고 다음요소가 같은 노드 즉, 노드가 하나일 경우
            {
                head = null; // 리스트에서 최상위 노드 제거
            }
            else // 아닐 경우
            {
                // 그림으로 이해
                // 1. [Prev]<=>[removeNode]<=>[Next]
                removeNode.Prev.Next = removeNode.Next; // 2. [Prev]<=[removeNode]<=>[Next], [Prev]<=[Next]
                removeNode.Next.Prev = removeNode.Prev; // 3. [Prev]<=[removeNode]=>[Next], [Prev]<=>[Next]
            }

            removeNode = null; // 4. [removeNode] 메모리 해제
            // 5. [Prev][Next]
        }

        /// <summary>
        /// 노드 검색
        /// </summary>
        /// <param name="index">노드의 인덱스 번호</param>
        /// <returns>검색한 노드 반환</returns>
        public DoublyLinkedListNode<T> GetNode(int index)
        {
            if (head == null) return null; // 최상위 노드가 없을 경우(리스트가 비어 있을 경우) null 반환

            int count = 0;
            DoublyLinkedListNode<T> current = head; // 최상위 노드 가져오기
            while (count < index) // index의 수만큼 반복
            {
                current = current.Next; // 가져온 현재 노드(current)에 다음 노드(current.Next)를 초기화
                count++; // 개수 증감

                // 현재 노드와 최상위 노드가 같을 경우 null 반환
                // (인자로 받은 값이 리스트 개수 보다 크다는 것을 의미)
                if (current == head)
                {
                    return null;
                }
            }

            return current; // 검색된 노드 반환
        }

        /// <summary>
        /// 리스트에 저장된 노드의 개수
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            if (head == null) return 0; // 최상위 노드가 비어 있을 경우 0 반환

            int count = 0;
            DoublyLinkedListNode<T> current = head;  // 현재 최상위 노드 가져오기
            do
            {
                count++; // 개수 증감
                current = current.Next; // 현재 노드를 다음 노드로 초기화
            }
            while (current != head); // 현재 노드가 최상위 노드와 일치할 경우 종료

            return count; // 개수 반환
        }

        /// <summary>
        /// 리스트가 원형 연결 리스트인지 확인
        /// </summary>
        /// <param name="head">리스트의 최상위 노드</param>
        /// <returns>원형 연결 리스트 여부</returns>
        public static bool IsCircular(DoublyLinkedListNode<T> head)
        {
            if (head == null) return true; // 리스트가 비어 있을 경우 원형 연결 리스트로 정의

            DoublyLinkedListNode<T> current = head; // 최상위 노드 가져오기
            
            while (current != null)  // 현재 노드가 null 일 경우 종료
            {
                current = current.Next; // 다음 노드를 현재 노드에 반복하여 초기화
                
                if (current == head) // 리스트가 순회하면서 헤드와 현재 노드가 일치할 경우 원형 연결 리스트
                {
                    return true;
                }
            }

            return false; // 원형 연결 리스트가 아닐경우 반환
        }


        /// <summary>
        /// 중간에 사이클이 존재 여부 검사
        /// </summary>
        /// <param name="head">최상위 노드</param>
        /// <returns>사이클 여부</returns>
        public static bool IsCyclic(SinglyLinkedListNode<int> head)
        {
            SinglyLinkedListNode<int> p1 = head; // 한칸씩 이동하는 노드
            SinglyLinkedListNode<int> p2 = head; // 두칸씩 이동하는 노드

            do
            {
                // 그림으로 이해
                // 1. 아래 그림과 같은 형태 일 경우
                // [ 1 ]→[ 2 ]→[ 3 ]→[ 4 ]
                //                 ↑      ↓
                //               [ 6 ]→[ 5 ]

                // 2. 각 노드의 이동 순서
                // p1 : 1 → 2 → 3 → 4 → "5" → 6 → 3 → 4 → "5" → 6
                // p2 : 1 → 3 → 5 → 3 → "5" → 3 → 5 → 3 → "5" → 3

                // 3. 위 그림에서 처럼 "5" 에서 중복 발생

                p1 = p1.Next; // 다음 노드로 이동
                p2 = p2.Next; // 다음 노드로 이동
                if (p1 == null || p2 == null || p2.Next == null) // 검색 요소 중 하나라도 null일 경우 원형 연결 리스트가 아님
                {
                    return false;
                }
                p2 = p2.Next; // 한번 더 다음 노드로 이동
            }
            while (p1 != p2); // 각 노드가 일치할 경우 종료

            return true;
        }

    }
}
