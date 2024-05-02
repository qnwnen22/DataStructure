using System;

namespace DataStructure.Array
{
    public class MyList<T>
    {
        private T[] array;
        private const int growthFactor = 2;
        public int Capacity
        {
            get { return array.Length; }
        }

        public int Count { get; private set; }

        public MyList(int capacity = 16)
        {
            array = new T[capacity];
        }


        public void Add(T t)
        {
            if (Count >= Capacity)
            {
                T[] tempArray = new T[Capacity * growthFactor]; ;
                for (int i = 0; i < array.Length; i++)
                {
                    tempArray[i] = array[i];
                }
                array = tempArray;
            }

            array[Count] = t;
            Count++;
        }

        public T Get(int index)
        {
            if (index >= Count) throw new Exception("요소 없음");
            return array[index];
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }


        public void Remove(int index)
        {
            if (index >= Count) return;

            if (index == Count - 1)
            {
                array[index] = default;
            }
            else
            {
                for (int i = index; i < Capacity; i++)
                {
                    T next = array[index + 1];
                    array[index] = next;
                    if (next == null) break;
                }
            }
            Count--;
        }
    }
}
