
namespace _020723_Bubblesort
{
    class Test
    {
        public int[] Sorter(int[] arr)
        {
            int temp; // creates a temp holder for a number when it gets swapped

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1]) // checks if the current number is bigger than the next
                    {
                        temp = arr[j]; // stores the current number in the temp
                        arr[j] = arr[j + 1]; // replaces the current with the next number
                        arr[j + 1] = temp; // replaces the next number with the current that got stored in the temp holder
                    }
                }
            }
            return arr;
        }
    }

}

