
using System;
using System.Runtime.ExceptionServices;

namespace temp2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Test
    {
        #region theSameInBoth
        public bool theSameInBoth(int[] a, int[] b)
        {
            int iter = 0;
            
            while(iter < a.Length)
            {
                if (a[iter] != b[iter])
                {
                    iter++;
                    return false;
                }
            }
            
            return true;
        }
        #endregion

        #region sumOfBothArrays
        public int[] sumOfBothArrays(int[]a, int[] b)
        {
            List<int> sum = new List<int>();

            int temp = 0;
            int iter = 0;
            while(iter < a.Length)
            {
                temp = a[iter] + b[iter];
                sum.Add(temp);
                iter++;
            }
            
            return sum.ToArray();
        }
        #endregion

        #region lengthOffTheWords
        public int[] lenghtOffTheWords(string[] list)
        {
            
        }

        #endregion

    }
}