
using System.Runtime.InteropServices;

namespace _020223_printing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ar = {7, 5, 3, 9, 8, 2};
            Print printer = new Print();

            Console.WriteLine("all the numbers in the array:");
            printer.PrintArr(ar);

            Console.WriteLine();
            Console.Write("What would you like to check if it's in the array? ");
            int check = int.Parse(Console.ReadLine());
            Console.WriteLine(printer.IsInArray(ar, check));
        }
    }
}
