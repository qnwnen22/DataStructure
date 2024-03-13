﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var words1 = new string[] { "tank", "kick", "know", "wheel", "land", "dream", "mother", "robot", "tank" };
            var r1 = Solution(3, words1);
            var str = r1.ToString();
            var words2 = new string[] { "hello", "observe", "effect", "take", "either", "recognize", "encourage", "ensure", "establish", "hang", "gather", "refer", "reference", "estimate", "executive" };
            var r2 = Solution(5, words2);
            var words3 = new string[] { "hello", "one", "even", "never", "now", "world", "draw" };
            var r3 = Solution(2, words3);
        }

        public static int[] Solution(int n, string[] words)
        {
            var result = new int[] { 0, 0 };

            var dic = new Dictionary<string, int>();

            int current = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (current == n)
                {
                    current = 0;
                }
                string word = words[i];

                if (dic.Count > 0)
                {
                    string last = dic.Keys?.Last();
                    
                    char lastChar = last.Last();
                    char firstChar = word.First();
                    bool isContains = dic.ContainsKey(word);
                    
                    if (lastChar != firstChar || isContains)
                    {
                        int num = current + 1;
                        double cal = (double)(dic.Count + 1) / (double)n;
                        int turn = (int)Math.Ceiling(cal);
                        result = new int[] { num, turn };
                        break;
                    }
                    else
                    {
                        dic.Add(word, current);
                    }
                }
                else
                {
                    dic.Add(word, 0);
                }
                current++;
            }
            return result;
        }
    }
}
