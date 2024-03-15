using System;

namespace DataStructure.Trie
{
    public class Example
    {
        public static void Example1()
        {
            var trie = new SimpleTrie();

            trie.Insert("cat");
            trie.Insert("cam");
            trie.Insert("tea");
            trie.Insert("tee");
            trie.Insert("team");

            bool found = trie.Find("tea");
            Console.WriteLine($"tea: {found}");


            found = trie.Find("teen");
            Console.WriteLine($"teen: {found}");
        }

        public static void Example2()
        {
            var trie = new Trie();

            trie.Insert("프로");
            trie.Insert("프로그래밍");
            trie.Insert("프로그램");
            trie.Insert("안녕하신가요");
            trie.Insert("안녕하세요");

            bool found = trie.Find("프로그래밍");
            Console.WriteLine($"프로그래밍: {found}");

            found = trie.Find("안녕");
            Console.WriteLine($"안녕: {found}");
        }

        public static void Example3()
        {
            var trie = new Trie();

            trie.Insert("프로");
            trie.Insert("프로그래밍");
            trie.Insert("프로그램");
            trie.Insert("안녕하신가요");
            trie.Insert("안녕하세요");

            trie.Delete("안녕하세요");


            var results = trie.AutoComplete("프로");
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
