using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue.QueueUsingCircularArray();
            for (int i = 0; i < 15; i++)
            {
                q.Enqueue(i);
            }
        }
    }
}
