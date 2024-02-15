using System;

namespace DataStructure.Heap
{
    public class Exmaple
    {
        public static void Example1()
        {
            var heap = new MaxHeap();
            // 힙 속성을 따르는 값을 추가
            heap.Add(20);
            heap.Add(15);
            heap.Add(12);
            heap.Add(13);
            heap.Add(10);
            heap.Add(9);
            heap.Add(11);
            heap.Add(7);
            heap.Add(6);

            // 출력: 20 15 12 13 10 9 11 7 6
            heap.DebugDisplayArray();

            // 힙 속성에 위배되는 값을 추가하여
            // 힙 재정열을 테스트함
            heap.Add(17);

            // 출력: 20 17 12 13 15 9 11 7 6 10
            heap.DebugDisplayArray();

            // 최대값 하나 꺼내기
            int max = heap.Remove();
            Console.WriteLine(max); // 20

            // 출력: 17 15 12 13 10 9 11 7 6
            heap.DebugDisplayArray();
        }
    }
}
