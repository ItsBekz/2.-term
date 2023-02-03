
namespace _020223_Node
{
    class Program
    {
        public static void Main(string[] args)
        {
            Node list = new Node() { value = 1 };
            list.next = new Node() { value = 2 };
            list.next.next = new Node() { value = 3 };
            list.next.next.next = new Node() { value = 4 };
            list.next.next.next.next = new Node() { value = 5 };

            Node iteration;
            iteration = list;
            while(iteration != null)
            {
                Console.WriteLine(iteration.value);
                iteration = iteration.next;
            }

            Console.ReadKey();



        }
    }

    class Node
    {
        public Node next;
        public int value;
    }
}