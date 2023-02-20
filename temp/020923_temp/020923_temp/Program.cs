
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using static _020923_temp.Test2;

namespace _020923_temp
{
    class Test
    {
        /*
        public static void Main(string[] args)
        {
            string[] s = { "hi", "hello", "car" };
            lengthOffTheWords(s);
        }
        */

        public static int[] lengthOffTheWords(string[] list)
        {
            int[] output = new int[list.Length];
            int temp = 0;
            int iter = 0;

            while(iter < list.Length)
            {
                temp = list[iter].Length;
                output[iter] = temp;
                iter++;
            }
            return output;
        }
    }





    class Test2
    {
        public static void Main(string[] args)
        {
            Node test2 = new Node(1);
            Node test3 = new Node(2);
            Node test4 = new Node(3);
            Node test5 = new Node(4);

            test2.next = test3;
            test3.next = test4;
            test4.next = test5;

            PrintLinkedList(test2);
            moveLastToFirst(test2);
            Console.WriteLine("------------------");
            PrintLinkedList(test2);

        }

        /*
        public static Node moveLastToFirst(Node n)
        {
            if(n == null || n.next == null) // a check to see if the linked list only has one element or is empty.
            {
                return n; // returns the node as it is since there is no node to move.
            }

            Node current = n;
            while(current.next != null) // this loop will keep going as long as the next node of the current node is not null.
            {
                current = current.next; // At some point current, will point to the second-to-last node in the linked list.
            }
            Node last = current.next; // makes a ref to last, and saves the last node in it.
            current.next = null; // now we make the last node null.
            last.next = n; // setting the last.next to n, so that the connected linked list can continue from there
            n = last; // setting the original n to the last node.

            return n;
        }
        */
        public static Node moveLastToFirst(Node n)
        {

        }

        public class Node 
        {
            public Node(int va)
            {
                value = va;
            }

            public int value;
            public Node next;
        }
        public static void PrintLinkedList(Node n)
        {
            Node current = n;
            while (current != null)
            {
                Console.Write(current.value + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
