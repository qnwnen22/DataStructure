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
            var concurrentStack = new ConcurrentStack<int>(); // 닷넷에서 지원하는, 멀티쓰레드 환경에서 Locking처리가 되어있는 큐 클래스

            // 0.1 초마다 스택에 데이터를 삽입하는 쓰레드
            Task tPush = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    concurrentStack.Push(i);
                    Thread.Sleep(100);
                }
            });

            // 0.15 초마다 스택에 데이터를 반환하는 쓰레드
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

            Task.WaitAll(tPush, tPop); // 두 쓰레드가 끝날 때 까지 대기
        }

        public static void Example2()
        {
            string[] tokens = "2 * 3.4 + ( 15 - 2 ) / 2".Split(' ');
            decimal result = Calculator.Evalute(tokens);
            Console.WriteLine(result);
        }
    }
}
