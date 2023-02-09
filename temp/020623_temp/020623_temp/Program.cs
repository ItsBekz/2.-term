
namespace _020223_temp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] IN = { 1, 2, 3, 3, 2, 1 };
            int[] IN2 = { 1, 2, 3, 3, 2, 1 };

            Console.WriteLine(Test.mirrorArray(IN));
            Console.WriteLine(Test.mirrorArray(IN2));
        }
    }
    
    class Test
    {
        public static bool mirrorArray(int[] arr)
        {
            int length = arr.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (arr[i] != arr[length - i - 1])
                {
                    return false;
                }
            }
            return true;

            /// 1 2 3 3 2 1
            /// int lenght = 6;
            /// arr[0] != arr[6-0-1]
            /// arr[0] != arr[5] - arr[0] = 1 & arr[5] = 1 
            /// arr[1] != arr[6-1-1]
            /// arr[1] != arr[4] - arr[1] = 2 & arr[4] = 2
        }
    }
}
