using System;

namespace DataStructure.LinkedList
{
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head; // 최상위 노드

        /// <summary>
        /// 리스트에 새로운 요소 삽입
        /// </summary>
        /// <param name="newNode">삽입할 노드</param>
        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null) // 최상위 노드가 비어 있을 경우
            {
                head = newNode; // 최상위 노드에 초기화
            }
            else // 최상위 노드가 비어 있지 않을 경우
            {
                DoublyLinkedListNode<T> current = head; // 최상위 노드 가져오기

                // 마지막 요소까지 접근할 때 까지 current에 current.Next 초기화를 반복
                while (current != null && current.Next != null) // current.Next가 null 일 경우 (마지막 노드까지 도달한 경우) 종료
                {
                    current = current.Next;
                }

                // 각각의 노드를 양방향으로 연결

                // 그림으로 이해
                // 1. [current], [newNode]
                current.Next = newNode; // 2. [current]<=>[newNode], [newNode]
                newNode.Prev = current; // 3. [current][newNode], [current]<=>[newNode]
                // 4. [current][newNode]

                newNode.Next = null;
            }
        }

        /// <summary>
        /// 현재 노드와 다음 노드 사이에 새로운 노드를 추가
        /// </summary>
        /// <param name="current">다음 노드 사이에 추가할 현재 노드</param>
        /// <param name="newNode">추가할 노드</param>
        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null) // 예외 처리
            {
                throw new Exception();
            }

            // 그림으로 이해
            // 1. [current][current.Next], [newNode]
            newNode.Next = current.Next; // 2. [current], [newNode]<=[current.Next]
            current.Next.Prev = newNode; // 3. [current], [newNode]<=>[current.Next]
            newNode.Prev = current; // 4. [current]=>[newNode][current.Next]
            current.Next = newNode; // 5. [current]<=>[newNode][current.Next]
            // 6. [current][newNode][current.Next]
        }

        /// <summary>
        /// 리스트에 특정 노드를 제거
        /// </summary>
        /// <param name="removeNode">제거할 노드</param>
        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null) // 노드가 비어 있을 경우 반환
            {
                return;
            }

            if (removeNode == head) // 삭제할 노드와 최상위 노드가 같을 경우
            {
                head = head.Next; // 다음 노드를 최상위 노드로 초기화
                if (head != null)
                {
                    head.Prev = null; // 최상위 노드로 초기화된 노드(다음 노드)의 이전 노드(Prev) 메모리 해제
                }
            }
            else // 삭제할 노드가 최상위 노드와 다를 경우
            {
                // 그림으로 이해
                // 1. [prev][removeNode][next]
                removeNode.Prev.Next = removeNode.Next; // 2. [prev]<=[next], [removeNode][next]
                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev; // 3. [prev]<=>[next], [removeNode]
                }
            }
            // 4. [prev][next]
            removeNode = null; // 제거한 노드 메모리 해제
        }

        /// <summary>
        /// 인덱스에 위치한 노드 검색
        /// </summary>
        /// <param name="index">검색할 인덱스</param>
        /// <returns>검색한 노드</returns>
        public DoublyLinkedListNode<T> GetNode(int index)
        {
            DoublyLinkedListNode<T> current = head; // 최상위 노드 가져오기
            
            // 인덱스 만큼 현재 노드(current)의 다음 노드(current.Next)를 초기화를 반복
            // 인덱스의 수만큼 반복되거나 초기화된 다음노드(current)가 null일 경우 종료
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            return current; // 검색된 노드 반환
        }

        /// <summary>
        /// 리스트에 저장된 노드의 개수
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int count = 0;

            DoublyLinkedListNode<T> current = head; // 현재 최상위 노드 가져오기
            while (current != null) // 가져온 현재 노드가 null 일 경우 종료
            {
                count++; // 개수 증감
                current = current.Next; // 가져온 현재 노드에 다음 노드를 반복하여 초기화
            }
            return count; // 순회를 돌면서 cnt 가 증감된 수 만큼 반환
        }
    }
}
