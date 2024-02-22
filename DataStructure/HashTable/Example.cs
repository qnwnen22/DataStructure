using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructure.HashTable
{
    public class Example
    {
        public static void Example1()
        {
            // Bucket 배열크기 4로 설정
            HashTable ht = new HashTable(4);

            // 6개 엔트리 추가
            ht.Add("James", "425-433-2323");
            ht.Add("Tom", "425-323-1336");
            ht.Add("Jane", "425-733-9853");
            ht.Add("Sam", "425-834-4357");
            ht.Add("Kate", "425-212-3757");
            ht.Add("Ted", "425-744-5557");

            // Bucket 배열 출력
            ht.DebugPrintBuckets();
            Console.WriteLine();

            // Key로부터 Value 얻기
            object val = ht.Get("Jane");
            Console.WriteLine(val);

            // Key가 있는지 체크
            if (ht.Contains("Samuel"))
            {
                Console.WriteLine("Samuel: Found");
            }
            else
            {
                Console.WriteLine("Samuel: Not Found");
            }
        }

        public static void Example2()
        {
            Hashtable ht = new Hashtable();

            ht.Add("James", "425-433-2323");
            ht.Add("Tom", "425-323-1336");
            ht.Add("Jane", "425-733-9853");
            ht.Add("Sam", "425-834-4357");
            ht.Add("Kate", "425-212-3757");
            ht.Add("Ted", "425-744-5557");

            // Key 체크
            if (ht.ContainsKey("Jane"))
            {
                // Key로부터 Value 얻기
                object val = ht["Jane"];
                Console.WriteLine(val);
            }

            // Key 모두 출력. Key는 입력된
            // 순서와 무관하게 출력

            foreach (var key in ht.Keys)
            {
                Console.WriteLine(key);
            }
        }

        public static void Example3()
        {
            var dict = new Dictionary<string, int>();

            // 이름과 나이 쌍
            dict.Add("James", 25);
            dict.Add("Tom", 35);
            dict.Add("Jane", 46);

            // Key 체크
            if (dict.ContainsKey("Jane"))
            {
                // Key로부터 Value 얻기
                int age = dict["Jane"];
                Console.WriteLine(age);
            }

            // 삭제
            dict.Remove("Tom");

            // 루프를 통해 KeyValuePair 가져오기
            foreach (KeyValuePair<string, int> keyValue in dict)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }
        }

        public static void Example4()
        {
            var dict = new ConcurrentDictionary<string, int>();

            // 이름과 나이 쌍 추가
            dict.TryAdd("James", 25);
            dict.TryAdd("Tom", 35);
            dict.TryAdd("Jane", 46);

            // 수정: 46을 47로 변경
            // (순서 주의: 2번째가 새 값)
            bool updated = dict.TryUpdate("Jane", 47, 46);

            // 읽기
            int age;
            bool exists = dict.TryGetValue("Jane", out age);
            if (exists)
            {
                Console.WriteLine(age);
            }

            // 삭제
            bool deleted = dict.TryRemove("Tom", out age);

            // 루프를 통해 전체 읽기
            foreach (var kv in dict)
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
        }

        public static void Example5()
        {
            var dict = new ConcurrentDictionary<int, string>();

            Task t1 = Task.Factory.StartNew(() =>
            {
                int key = 1;
                while (key <= 100)
                {
                    if (dict.TryAdd(key, "D" + key))
                    {
                        key++;
                    }
                    Thread.Sleep(100);
                }
            });

            Task t2 = Task.Factory.StartNew(() =>
            {
                int key = 1;
                string val;
                while (key <= 100)
                {
                    if (dict.TryGetValue(key, out val))
                    {
                        Console.WriteLine($"{key}: {val}");
                        key++;
                    }
                    Thread.Sleep(100);
                }
            });

            Task.WaitAll(t1, t2);
        }

    }
}
