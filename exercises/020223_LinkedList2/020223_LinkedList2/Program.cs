
using Microsoft.VisualBasic;

namespace _020223_LinkedList2
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            /*
            MinStack ms = new MinStack();
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            ms.Push(4);
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            */

            /*
            MinStack2 ms = new MinStack2();
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            ms.Push(4);
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            
        }*/
    }

    // stack with array
    public class MinStack
    {
        private int[] arr = new int[100];
        private int iter = 0; // keeps track of where we are
        public void Push(int item)
        {
            arr[iter] = iter +1;
            iter = iter + 1; // this make the position of the iterater move
        }

        public int Pop()
        {
            int ans = arr[iter-1];
            iter = iter - 1;

            return ans;
        }
        public bool isEmpty()
        {
            bool ans = false;
            if (iter == null)
                ans = true;

            return ans;
        }
    }


    // stack with LinkedList
    public class MinStack2
    {
        private Node start;
        public void Push(int item)
        {
            Node n = new Node();
            n.value = item;
            n.next = start;
            start = n;
        }

        public int Pop()
        {
            int ans = start.value;
            start = start.next;
            return ans;
        }
        public bool isEmpty()
        {
            bool ans = false;
            if (start != null)
                ans = true;

            return ans;
        }
        public class Node
        {
            public Node next;
            public int value;
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            //Queue<String> minKø = new Queue<string>();
            MinQueue minKø = new MinQueue();
            minKø.Enqueue("Der");
            minKø.Enqueue("var");
            minKø.Enqueue("engang");
            minKø.Enqueue("en");
            minKø.Enqueue("princesse");
            Console.WriteLine(minKø.Dequeue());
        }
    }

    public class MinQueue
    {
        private Node start;
        public void Enqueue(string item)
        {
            Node n = new Node();
            n.value = item;
            n.next = start;
            start = n;
        }
        
        public string Dequeue()
        {
            string ans = start.value;
            start = start.next;
            return ans;
        }

        public class Node
        {
            public Node next;
            public string value;
        }
    }

}

