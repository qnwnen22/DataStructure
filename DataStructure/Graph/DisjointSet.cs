using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class DisjointSet
    {
        // 해시테이블(요소 => 부모)
        private Dictionary<string, string> ht;

        public DisjointSet()
        {
            ht = new Dictionary<string, string>();
        }

        public void CreateSet(string element)
        {
            //부모가 요소와 동일함
            ht.Add(element, element);
        }

        public string Find(string element)
        {
            if (ht[element] == element)
            {
                //부모가 요소와 동일하면 최상위 부모
                return element;
            }
            else
            {
                return Find(ht[element]);
            }
        }

        public void Union(string elem1, string elem2)
        {
            //병합: elem1의 부모를 elem2로 지정
            ht[elem1] = elem2;
        }
    }
}
