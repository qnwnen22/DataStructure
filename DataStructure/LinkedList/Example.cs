using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.LinkedList
{
    public class Example
    {
        public static void Example1()
        {
            // 정수형 단일 연결 리스트 생성
            var list = new SinglyLinkedList<int>();

            // 리스트에 0~4 추가
            for (int i = 0; i < 5; i++)
            {
                list.Add(new SinglyLinkedListNode<int>(i));
            }
            
            SinglyLinkedListNode<int> node = list.GetNode(2); // index가 2인 노드 가져오기
            list.Remove(node); // 리스트에서 index가 2인 노드 삭제

            node = list.GetNode(1); // index가 1인 노드 가져오기
            list.AddAfter(node, new SinglyLinkedListNode<int>(100)); // 가져온 노드 뒤에 100 삽입

            int count = list.Count(); // 리스트에 저장된 노드, 총 개수 확인

            // 전체 리스트 출력
            for (int i = 0; i < count; i++)
            {
                SinglyLinkedListNode<int> getNode = list.GetNode(i);
                Console.Write($"{getNode.Data} ");
            }
            // 결과: 0 1 100 3 4 
        }

        public static void Example2()
        {
            var list = new DoublyLinkedList<int>(); // 정수형 이중 연결 리스트 생성

            // 리스트에 0 ~ 4 추가
            for (int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2); // 2번째 인덱스 노드 가져오기
            list.Remove(node); // 가져온 노드 삭제

            node = list.GetNode(1); // 1번째 인덱스 노드 가져오기
            var newNode = new DoublyLinkedListNode<int>(100); // 100이 저장된 노드 생성
            list.AddAfter(node, newNode); // 가져온 노드(인덱스가 1인 노드) 뒤에 생성한 노드를 추가

            int count = list.Count(); // 리스트에 있는 노드의 개수 반환

            for (int i = 0; i < count; i++) // 리스트의 개수반큼 루프
            {
                var n = list.GetNode(i); // i번째 노드 가져오기
                Console.WriteLine(n.Data); // 노드에 저장된 값 출력
            }
            
            node = list.GetNode(4); // 4번째 노드 가져오기
            
            // 가져온 노드를 기준으로 역으로 순회하여 출력
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Prev;
            }
        }

        public static void Example3()
        {
            var list = new CricularLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2);
            list.Remove(node);

            node = list.GetNode(1);
            var newNode = new DoublyLinkedListNode<int>(100);
            list.AddAfter(node, newNode);

            int count = list.Count();

            node = list.GetNode(0);
            for (int i = 0; i < count * 2; i++)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }

        public static void Example4()
        {
            var list = new LinkedList<string>();
            list.AddLast("Appple");
            list.AddLast("Banana");
            list.AddLast("Lemon");

            var node = list.Find("Banana");
            var newNode = new LinkedListNode<string>("Grape");

            list.AddAfter(node, newNode);

            list.ToList().ForEach(x => Console.WriteLine(x));

            list.Remove("Grape");

            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
