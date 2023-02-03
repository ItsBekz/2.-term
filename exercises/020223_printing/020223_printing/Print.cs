using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020223_printing
{
    public class Print
    {
        public void PrintArr(int[] ar)
        {
            foreach (int i in ar)
            {
                Console.WriteLine(i);
            }
        }

        public void PrintLast(int[] ar)
        {
            Console.WriteLine("last number in the array: " + ar[ar.Length - 1]);
        }

        public bool IsInArray(int[] arr, int i)
        {
            int check = 0;
            bool isIn = false;
            while (check < arr.Length)
            {
                if (arr[check] == i)
                {
                    isIn = true;
                    break; // break to stop the loop
                }
                else
                {
                    check++;
                }
            }
            return isIn;
        }
    }
}
