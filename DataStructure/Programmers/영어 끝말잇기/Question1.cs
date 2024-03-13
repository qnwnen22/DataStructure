using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Programmers
{
    /// <summary>
    /// https://school.programmers.co.kr/learn/courses/30/lessons/12981
    /// </summary>
    class Question1
    {
        /// <summary>
        /// 영어 끝말잇기
        /// </summary>
        /// <param name="n">참여자 수</param>
        /// <param name="words">끝말잇기 리스트</param>
        /// <returns>[ 번호, 차례 ]</returns>
        public int[] Solution(int n, string[] words)
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
