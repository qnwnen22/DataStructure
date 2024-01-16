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

            // index가 2인 요소 삭제
            SinglyLinkedListNode<int> node = list.GetNode(2);
            list.Remove(node);

            // index가 1인 요소 가져오기
            node = list.GetNode(1);
            // index가 1인 요소 뒤에 100 삽입
            list.AddAfter(node, new SinglyLinkedListNode<int>(100));

            // 리스트 카운터 체크
            int count = list.Count();

            // 전체 리스트 출력
            // 결과: 0 1 100 3 4
            for (int i = 0; i < count; i++)
            {
                SinglyLinkedListNode<int> n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }
        }

        public static void Example2()
        {
            var list = new DoublyLinkedList<int>();

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

            for (int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }
            node = list.GetNode(4);
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
