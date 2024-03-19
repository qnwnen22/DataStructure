using System;
using System.Collections.Generic;

namespace DataStructure.Graph.UsingLinkedList
{
    public class Node
    {
        public string Key { get; }
        public LinkedList<Edge> EdgeList { get; }
        public Node(string key)
        {
            this.Key = key;
            this.EdgeList = new LinkedList<Edge>();
        }
    }
}
