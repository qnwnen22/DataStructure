using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructure.Stack
{
    public class Example
    {
        public static void Example1()
        {
            var concurrentStack = new ConcurrentStack<int>();

            Task tPush = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    concurrentStack.Push(i);
                    Thread.Sleep(100);
                }
            });

            Task tPop = Task.Factory.StartNew(() =>
            {
                int n = 0;
                int result;
                while (n < 100)
                {
                    if (concurrentStack.TryPop(out result))
                    {
                        Console.WriteLine(result);
                        n++;
                    }
                    Thread.Sleep(150);
                }
            });

            Task.WaitAll(tPush, tPop);
        }

        public static void Example2()
        {
            string[] tokens = "2 * 3.4 + ( 15 - 2 ) / 2".Split(' ');
            decimal result = Calculator.Evalute(tokens);
            Console.WriteLine(result);
        }
    }
}
