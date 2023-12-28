namespace DataStructure.Array
{
    public class DynamicArray1
    {
        private object[] arr = new object[0];

        public void Add(object element)
        {
            var temp = new object[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }
            arr = temp;

            arr[arr.Length - 1] = element;
        }
    }
}
