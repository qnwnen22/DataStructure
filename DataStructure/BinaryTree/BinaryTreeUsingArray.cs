using System;

namespace DataStructure.BinaryTree
{
    public class BinaryTreeUsingArray
    {
        private object[] array;

        public BinaryTreeUsingArray(int capacity = 15)
        {
            array = new object[capacity];
        }

        public object Root
        {
            get => array[0];
            set => array[0] = value;
        }

        /// <summary>
        /// 왼쪽 자식노드에 추가
        /// </summary>
        /// <param name="parentIndex">부모 노드 인덱스</param>
        /// <param name="data">삽입할 데이터</param>
        public void SetLeft(int parentIndex, object data)
        {
            int leftIndex = parentIndex * 2 + 1; // 왼쪽 자식노드 공식

            // 부모 노드가 null이거나 검색한 인덱스가 배열의 크기 이상일 경우 예외 처리
            if (array[parentIndex] == null || leftIndex >= array.Length)
            {
                throw new Exception();
            }

            array[leftIndex] = data;
        }

        /// <summary>
        /// 오른쪽 자식노드에 추가
        /// </summary>
        /// <param name="parentIndex">부모 노드 인덱스</param>
        /// <param name="data">삽입할 데이터</param>
        public void SetRigth(int parentIndex, object data)
        {
            int rigthIndex = parentIndex * 2 + 2; // 오른쪽 자식노드 공식

            // 부모 노드가 null이거나 검색한 인덱스가 배열의 크기 이상일 경우 예외 처리
            if (array[parentIndex] == null || rigthIndex >= array.Length)
            {
                throw new Exception();
            }

            array[rigthIndex] = data;
        }

        /// <summary>
        /// 부모 노드를 반환
        /// </summary>
        /// <param name="childIndex">자식 노드 인덱스</param>
        /// <returns>부모 노드</returns>
        public object GetParent(int childIndex)
        {
            if (childIndex == 0) return null; // 0 은 최상위 노드이기 때문에 null 반환

            int parentIndex = (childIndex - 1) / 2; // 부모 노드 공식
            return array[parentIndex];
        }

        /// <summary>
        /// 왼쪽 자식노드 반환
        /// </summary>
        /// <param name="parentIndex">부모 노드 인덱스</param>
        /// <returns>왼쪽 자식 노드</returns>
        public object GetLeft(int parentIndex)
        {
            int leftIndex = parentIndex * 2 + 1; // 왼쪽 자식노드 공식
            return array[leftIndex];
        }
        
        /// <summary>
        /// 오른쪽 자식노드 반환
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        public object GetRigth(int parentIndex)
        {
            int rightIndex = parentIndex * 2 + 2; // 오른쪽 자식노드 공식
            return array[rightIndex];
        }

        /// <summary>
        /// 저장된 트리를 출력
        /// </summary>
        public void PrintTree()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i] ?? "_");
            }
            Console.WriteLine();
        }
    }
}
