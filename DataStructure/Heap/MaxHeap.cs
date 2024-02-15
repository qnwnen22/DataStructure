using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Heap
{
    // 동적 배열을 이용한 Max Heap 구현
    public class MaxHeap
    {
        // 동적 배열
        private List<int> arr = new List<int>();

        public void Add(int data)
        {
            arr.Add(data);

            int i = arr.Count - 1;

            // Reheapification upward
            while (i > 0)
            {
                int parent = (i - 1) / 2;

                if (arr[i] > arr[parent])
                {
                    // Swap
                    int tmp = arr[i];
                    arr[i] = arr[parent];
                    arr[parent] = tmp;

                    // 계속 체크
                    i = parent;
                }
                else
                {
                    break;
                }
            }
        }

        public int Remove()
        {
            if (arr.Count == 0)
            {
                throw new Exception();
            }

            // 루트 최대값 저장
            int data = arr[0];

            // 마지막 요소를 처음으로 이동
            arr[0] = arr[arr.Count - 1];
            // 마지막 요소 제거
            arr.RemoveAt(arr.Count - 1);

            //Reheapification downward
            int i = 0;
            int last = arr.Count - 1;
            while (i < last)
            {
                // 왼쪽 자식노드
                int child = 2 * i + 1;

                // 오른쪽 자식노드가 더 크면 오른쪽 선택
                if (child < last && arr[child] < arr[child + 1])
                {
                    child++;
                }

                // 인덱스가 초과되거나
                // 자식노드보다 크거나 같으면 중지
                if (child > last || arr[i] >= arr[child])
                {
                    break;
                }

                // Swap
                int tmp = arr[i];
                arr[i] = arr[child];
                arr[child] = tmp;

                // 계속 체크
                i = child;
            }

            return data;
        }

        internal void DebugDisplayArray()
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }
    }
}
