using System;

namespace DataStructure.LinkedList
{
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null) // 리스트가 비어 있으면
            {
                head = newNode;
            }
            else // 비어 있지 않으면
            {
                DoublyLinkedListNode<T> current = head;
                while (current != null && current.Next != null) // 마지막으로 이동하여 추가
                {
                    current = current.Next;
                }

                // 추가할 때 양방향 연결
                current.Next = newNode;
                newNode.Prev = current;
                newNode.Next = null;
            }
        }

        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new Exception("전부다 null");
            }

            newNode.Next = current.Next; // 새 노드의 다음 포인트에 현재의 다음 포인트 연결
            current.Next.Prev = newNode; // 다음 노드의 이전 포인트에 새 노드를 연결
            newNode.Prev = current; // 새 노드의 이전 포인트에 현재 노드를 연결
            current.Next = newNode; // 현재 노드의 다음 포인트에 새 노드를 연결
        }

        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null;

                }
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }
            }

            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            DoublyLinkedListNode<T> current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public int Count()
        {
            int count = 0;

            DoublyLinkedListNode<T> current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
