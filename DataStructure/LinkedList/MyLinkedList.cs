using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.LinkedList
{
    public class MyNode<T>
    {
        public T value;
        public MyNode<T> previous;
        public MyNode<T> next;

        public MyNode(T data)
        {
            this.value = data;
        }

    }

    public class MyLinkedList<T>
    {
        private MyNode<T> head;
        public int Count { get; private set; }

        public void Add(MyNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                MyNode<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
                newNode.previous = current;
            }
            Count++;
        }

        public void Add(T data)
        {
            var newNode = new MyNode<T>(data);
            Add(newNode);
        }

        public MyNode<T> Find(T data)
        {
            if (head == null || data == null) return null;
            MyNode<T> current = head;

            while (true)
            {
                if (current.value.Equals(data))
                {
                    return current;
                }
                if (current.next == null) return null;
                current = current.next;
            }
        }

        public void Remove(MyNode<T> removeNode)
        {
            if (head == null || removeNode == null) return;
            removeNode.previous.next = removeNode.next;
            removeNode.next.previous = removeNode.previous;
            removeNode = null;
            Count--;
        }
        public void Remove(T data)
        {
            MyNode<T> find = Find(data);
            Remove(find);
        }
    }
}
