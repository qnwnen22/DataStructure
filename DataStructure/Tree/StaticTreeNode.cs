namespace DataStructure.Tree
{
    public class StaticTreeNode
    {
        public object Data { get; set; }
        public StaticTreeNode[] Links { get; private set; }

        public StaticTreeNode(object data, int maxDegree = 3)
        {
            this.Data = data;
            Links = new StaticTreeNode[maxDegree];
        }
    }
}
