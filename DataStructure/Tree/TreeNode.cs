using System.Collections.Generic;

namespace DataStructure.Tree
{


    public class TreeNode
    {
        public object Data { get; set; }
        public List<TreeNode> Links { get; private set; }
        public TreeNode(object data)
        {
            this.Data = data;
            this.Links = new List<TreeNode>();
        }
    }
}
