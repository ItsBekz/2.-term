

namespace _020223_HowToTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            Console.WriteLine(t.FindSmallest(new int[] { -2, 5, 7, 9, -22, 1, 6, 7 }));
        }
    }

    class Test
    {
        public int FindSmallest(int[] arr)
        {
            int i = 0;
            int smallest = arr[0];
            while(i < arr.Length)
            {
                if (arr[i] < smallest) 
                {
                    smallest = arr[i]; 
                }
                i++;
            }
            return smallest;
        }
    }
}