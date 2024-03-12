namespace DataStructure.Tree
{
    public class LCRSNode
    {
        public object Data { get; set; }
        public LCRSNode LeftChild { get; set; }
        public LCRSNode RigthSibling { get; set; }
        public LCRSNode(object data)
        {
            this.Data = data;
        }
    }
}
