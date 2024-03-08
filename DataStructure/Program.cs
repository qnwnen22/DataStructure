using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue.QueueUsingLinkedList();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
        }
    }
}
