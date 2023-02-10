
namespace _021023_Recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            Recursive r = new Recursive();
            r.PrintTenTimes(1);
        }

        
    }

    class Recursive
    {
        public void PrintTenTimes(int i)
        {
            if(i <= 10)
            {
                Console.WriteLine(i);
                i++;
                PrintTenTimes(i);

            }
        }
    }
}

