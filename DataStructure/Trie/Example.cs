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
    }
}
