namespace DataStructure.Array
{
    public class DynamicArray2
    {
        private object[] arr;
        private const int GROWTH_FACTOR = 2; // 동적으로 배열의 크기(배수)
                                             // 2배만큼 동적 확장

        public int Count { get; private set; } // 현재 배열요소의 개수

        public int Capacity // 최대수용 용량
        {
            get
            {
                return arr.Length;
            }
        }

        public DynamicArray2(int capacity = 16) // 기본 배열의 크기 = 16
        {
            arr = new object[capacity];
            Count = 0;
        }

        public void Add(object element)
        {
            // 배열이 찼을 때 확장
            if (Count >= Capacity)
            {
                int newSize = Capacity * GROWTH_FACTOR; // GROWTH_FACTOR의 배수만큼 최대수용 용량 지정
                var temp = new object[newSize]; // 데이터를 복사할 배열 생성

                for (int i = 0; i < arr.Length; i++)
                {
                    temp[i] = arr[i]; // temp에 기존 데이터 복사
                }

                arr = temp; // 기존 배열을 복사한 배열로 초기화
            }

            arr[Count] = element; // 추가할 요소를 배열 마지막에 추가
            Count++; // 요소가 추가되었으니 카운터 증감
        }

        public object Get(int index)
        {
            if (index > Capacity - 1)
            {
                throw new System.Exception("Element not found");
            }

            return arr[index];
        }
    }
}
