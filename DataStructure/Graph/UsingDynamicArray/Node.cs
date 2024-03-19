using System;
using System.Collections.Generic;

namespace DataStructure.Graph.UsingDynamicArray
{
    /// <summary>
    /// 동적 배열로 구현된 노드와 그래프
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T Data { get; set; }
        public List<Node<T>> Neighbors { get; private set; }
        public List<int> Weights { get; private set; }

        public Node()
        {
            Neighbors = new List<Node<T>>();
            Weights = new List<int>();
        }

        public Node(T data) : this()
        {
            Data = data;
        }
    }

   
}
