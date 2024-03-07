namespace DataStructure.LinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public T Data { get; set; } // 저장할 데이터
        public DoublyLinkedListNode<T> Prev { get; set; } // 이전 데이터
        public DoublyLinkedListNode<T> Next { get; set; } // 다음 데이터
        public DoublyLinkedListNode(T data) : this(data, null, null) { } // 기본 생성자
        public DoublyLinkedListNode(T data, DoublyLinkedListNode<T> prev, DoublyLinkedListNode<T> next)
        {
            this.Data = data;
            this.Prev = prev;
            this.Next = next;
        }
    }
}
