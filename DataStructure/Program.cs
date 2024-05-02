using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var myLinkedList = new MyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                myLinkedList.Add(i);
            }
            myLinkedList.Remove(5);

            var linkedList = new System.Collections.Generic.LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(3);
            linkedList.AddLast(5);

            linkedList.Remove(3);

            var find =linkedList.Find(1);
        }
    }


    
}
