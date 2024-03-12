using System;
using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class LCRSTree
    {
        public LCRSNode Root { get; private set; }
        public LCRSTree(object rootData)
        {
            this.Root = new LCRSNode(rootData);
        }

        /// <summary>
        /// 자식노드 추가
        /// </summary>
        /// <param name="parent">부모 노드</param>
        /// <param name="data">추가할 데이터</param>
        /// <returns>추가한 노드</returns>
        public LCRSNode AddChild(LCRSNode parent, object data)
        {
            if (parent == null) return null; // 부모가 null일 경우 null을 반환

            var child = new LCRSNode(data); // 추가할 노드 생성

            if (parent.LeftChild == null) // 부모노드에 자식이 없을 경우 
            {
                parent.LeftChild = child; // 왼쪽 자식 노드로 추가
            }
            else // 자식이 있을 경우
            {
                LCRSNode node = parent.LeftChild; // 왼쪽 자식노드 가져오기

                // 오른쪽 형제 노드가 없는 노드를 순회하며 가져오기
                while (node.RigthSibling != null)
                {
                    node = node.RigthSibling;
                }
                node.RigthSibling = child; // 오른쪽 형제 노드가 없는 노드에 새 노드 추가
            }

            return child; // 추가한 노드 반환
        }

        /// <summary>
        /// 형제노드 추가
        /// </summary>
        /// <param name="node">기준이 되는 노드</param>
        /// <param name="data">추가할 데이터</param>
        /// <returns></returns>
        public LCRSNode AddBSibling(LCRSNode node, object data)
        {
            if (node == null) return null; // 노드가 null일 경우 null 반환

            // 기준이 되는 노드의 형제노드가 null인 노드를 찾을 때 까지 반복
            while (node.RigthSibling != null)
            {
                node = node.RigthSibling;
            }

            var sibling = new LCRSNode(data); // 새 노드 생성
            node.RigthSibling = sibling; // 형제노드가 null인 노드에 새 노드 추가

            return sibling; // 삽입한 노드 반환
        }

        /// <summary>
        /// 레벨순으로 트리노드를 출력
        /// </summary>
        public void PrintLevelOrder()
        {
            var queue = new Queue<LCRSNode>(); // 큐 생성
            queue.Enqueue(this.Root); // 큐에 최상위 노드 삽입

            while (queue.Count > 0) // 큐에 리스트가 0일 때까지 반복
            {
                LCRSNode node = queue.Dequeue(); // 저장된 요소 가져오기

                while (node != null) // 형제 노드가 null일때 까지 반복
                {
                    Console.Write($"{node.Data} "); // 요소 출력

                    if (node.LeftChild != null) // 자식노드가 null이 아닐 경우
                    {
                        queue.Enqueue(node.LeftChild); // 큐 리스트에 삽입
                    }

                    node = node.RigthSibling; // 현재 노드를 형제노드로 초기화
                }
            }

            //출력 결과
            //A B C D E F G

        }

        /// <summary>
        /// 들여쓰기 방식으로 트리 출력
        /// </summary>
        public void PrintIndexTree()
        {
            PrintIndent(this.Root, 1);

            // 출력 결과
            // -A
            //  -B
            //   -E
            //   -F
            //  -C
            //  -D
            //   -G
        }

        /// <summary>
        /// 들여쓰기 방식으로 트리 출력(오버라이딩)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="indent"></param>
        private void PrintIndent(LCRSNode node, int indent)
        {
            if (node == null) return; // node가 null일 경우 반환

            string whiteSpace = " ";
            string pad = whiteSpace.PadLeft(indent);
            Console.WriteLine($"{pad}-{node.Data}");

            PrintIndent(node.LeftChild, indent + 1);

            PrintIndent(node.RigthSibling, indent);
        }
    }
}
