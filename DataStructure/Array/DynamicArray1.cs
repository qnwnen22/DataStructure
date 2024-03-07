namespace DataStructure.Array
{
    public class DynamicArray1
    {
        private object[] arr = new object[0];

        // 동적 배열에 요소를 추가
        public void Add(object element)
        {
            object[] temp = new object[arr.Length + 1]; // 임시 배열 생성
                                                        // 생성한 배열은 기존 배열의 +1 만큼 크게 생성

            // temp에 기존 데이터 복사
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }

            arr = temp; // 복사한 temp를 기존 arr 필드에 초기화

            arr[arr.Length - 1] = element; // 새로운 요소를 추가
        }
    }
}
