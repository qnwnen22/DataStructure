using System;

namespace DataStructure.BTree
{
    public class Example
    {
        public static void Example1()
        {
            // B-tree 생성 및 삽입 테스트
            BTree<int> btree = new BTree<int>(2); // 2가 최소 차수
            btree.Insert(10);
            btree.Insert(20);
            btree.Insert(5);
            btree.Insert(6);
            btree.Insert(12);
            btree.Insert(30);
            btree.Insert(7);

            Console.WriteLine("B-tree 출력:");
            btree.Print();

            Console.ReadLine();
        }
    }
}
