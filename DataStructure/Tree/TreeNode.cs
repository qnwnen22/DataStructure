using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class TreeNode
    {
        public object Data { get; set; }
        //public TreeNode[] Links { get; private set; } // 고정 배열
        public List<TreeNode> Links { get; private set; } // 동적 배열

        ///// <summary>
        ///// 고정 배열 생성자
        ///// </summary>
        ///// <param name="data"></param>
        ///// <param name="maxDegree"></param>
        //public TreeNode(object data, int maxDegree = 3)
        //{
        //    this.Data = data;
        //    this.Links = new TreeNode[maxDegree];
        //}

        /// <summary>
        /// 공간 낭비를 해결하기 위한 동적 배열로 수정
        /// </summary>
        /// <param name="data"></param>
        public TreeNode(object data)
        {
            this.Data = data;
            this.Links = new List<TreeNode>();
        }
    }
}
