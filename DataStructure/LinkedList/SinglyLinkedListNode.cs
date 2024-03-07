namespace DataStructure.LinkedList
{
    public class SinglyLinkedListNode<T>
    {
        public T Data { get; set; } // 데이터
        public SinglyLinkedListNode<T> Next { get; set; } // 연결할 다음 노드
        public SinglyLinkedListNode(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}
