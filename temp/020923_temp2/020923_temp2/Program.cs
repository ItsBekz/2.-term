using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort ms = new MergeSort();
            int[] a = { 9, 2, 1, 4, 6, 5, 3, 8 };
            ms.mergeSortRecursive(a);
        }
    }
    class MergeSort
    {
        public void print(int[] ar)
        {
            //  Console.WriteLine("----------");
            int i = 0;
            while (i < ar.Length)
            {
                Console.Write("[ " + ar[i] + " ]");
                i = i + 1;
            }
            Console.WriteLine();
        }

        public int[] mergeSortRecursive(int[] ar)
        {
            Console.WriteLine("   [mergeSortRecursive() kaldt]  ");
            if (ar.Length == 1)
            {
                Console.WriteLine(" < STOP > kan ikke splitte mere.  ");
                return ar;
            }
            Console.WriteLine("-----Skal til at splitte følgende array:");
            print(ar);
            int midt = ar.Length / 2;
            int[] left = spiltArray(ar, 0, midt);
            Console.WriteLine("-----split Result: Left"); print(left);
            int[] right = spiltArray(ar, midt, ar.Length - midt);
            Console.WriteLine("-----split Result: Right"); print(right);
            Console.WriteLine("mergeSortRecursive(Left)");
            left = mergeSortRecursive(left);
            Console.WriteLine("mergeSortRecursive(Right)");
            right = mergeSortRecursive(right);
            Console.WriteLine("merge(Left, right) START");
            Console.WriteLine("LEFT"); print(left);
            Console.WriteLine("RIGHT"); print(right);
            ar = merge(left, right);
            Console.WriteLine("merge(Left, right) RESULT"); print(ar);
            return ar;
        }

        public int[] spiltArray(int[] ar, int posStart, int length)
        {
            int[] svar = new int[length];
            int i = 0;
            while (i < length)
            {
                svar[i] = ar[posStart];
                posStart++;
                i++;
            }
            return svar;
        }
        public int[] merge(int[] a, int[] b)
        {
            int i, j, k;
            i = j = k = 0;
            int[] svar = new int[a.Length + b.Length];

            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    svar[k] = a[i];
                    i++;
                    k++;
                }
                else
                {
                    svar[k] = b[j];
                    j++;
                    k++;
                }
            }
            while (i < a.Length)
            {
                svar[k] = a[i];
                i++;
                k++;
            }
            while (j < b.Length)
            {
                svar[k] = b[j];
                j++;
                k++;
            }
            return svar;
        }
    }
}
