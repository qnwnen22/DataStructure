using System;

namespace DataStructure.LinkedList
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> head; // 최상위 노드

        // 리스트에 새로운 요소를 추가
        public void Add(SinglyLinkedListNode<T> newNode)
        {
            if (head == null) // 최상위 노드가 없을 경우 
            {
                head = newNode; // 헤드에 초기화
            }
            else // 아닐 경우
            {
                SinglyLinkedListNode<T> current = head; // 현재 최상위 노드 가져오기

                // 연결된 노드가 없는 노드를 찾을 때 까지 current에 초기화 반복
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }

                // 찾은 노드에 새 요소 연결
                current.Next = newNode;
            }
        }

        /// <summary>
        /// 현재 노드와 다음 노드 사이에 새로운 노드를 추가
        /// </summary>
        /// <param name="current">다음 노드 사이에 추가할 현재 노드</param>
        /// <param name="newNode">추가할 노드</param>
        public void AddAfter(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null) // 예외처리
            {
                throw new Exception();
            }

            // 그림으로 이해
            // 1. [current][current.Next] , [newNode]
            newNode.Next = current.Next; // 2. [current], [newNode]<=>[current.Next]
            current.Next = newNode; // 3. [current]<=>[newNode][current.Next]
            // 4. [current][newNode][current.Next]
        }

        /// <summary>
        /// 리스트안에 특정 노드를 제거
        /// </summary>
        /// <param name="removeNode">제거할 노드</param>
        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null) // 최상위 노드나 제거할 노드가 null일 경우 연산을 마침
            {
                return;
            }

            if (removeNode == head) // 제거할 노드가 최상위 노드일 경우
            {
                head = head.Next; // 최상위 노드의 다음 노드를 최상위 노드로 초기화
                removeNode = null; // 제거할 노드 메모리 해제
            }
            else // 제거할 노드가 최상위 노드가 아닐 경우
            {
                SinglyLinkedListNode<T> current = head; // 현재 최상위 노드 가져오기

                // 현재 노드(current)에 다음 노드(current.Next)를 순차적으로 호출하면서 제거할 노드(removeNode)와 비교
                // current.Next와 removeNode가 일치할 경우 반복 종료
                while (current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    // current.Next == removeNode 이므로
                    // current.Next에 removeNode.Next를 초기화

                    // 그림으로 이해
                    // 1. [current][current.Next], [removeNode][removeNode.Next]
                    current.Next = removeNode.Next; // 2. [current]<=>[removeNode.Next], [removeNode]
                                                    // 3. [current][removeNode.Next]

                    removeNode = null;  // 제거된 노드 메모리 해제
                }
            }
        }

        /// <summary>
        /// 노드 검색
        /// </summary>
        /// <param name="index">노드의 인덱스 번호</param>
        /// <returns>검색한 노드 반환</returns>
        public SinglyLinkedListNode<T> GetNode(int index)
        {
            SinglyLinkedListNode<T> current = head; // 현재 최상위 노드 가져오기

            // index의 횟수 만큼 리스트를 순회하여 현재 노드(current)에 다음 요소(current.Next)를 초기화
            // 횟수가 끝나거나 current 가 null일 경우 종료
            for (int i = 0; i < index && current != null; i++) // current가 null일 경우 리스트의 마지막을 의미함
            {
                current = current.Next;
            }

            return current; // 검색된 노드를 반환
        }

        /// <summary>
        /// 리스트에 저장된 노드의 개수
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int cnt = 0;

            SinglyLinkedListNode<T> current = head; // 현재 최상위 노드 가져오기

            while (current != null) // 가져온 현재 노드가 null 일 경우 종료
            {
                cnt++; // 개수 증감
                current = current.Next; // 가져온 현재 노드에 다음 노드를 반복하여 초기화
            }

            return cnt; // 순회를 돌면서 cnt 가 증감된 수 만큼 반환
        }
    }
}
