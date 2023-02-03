
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace _020223_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            List minList = new List();
            minList.add(1);
            minList.add(2);
            minList.add(3);
            minList.printAll();
        }
    }
    class List
    {
        public Node start;
        public void add(int tal)
        {
            Node n = new Node();
            n.tal = tal;
            n.next = start;
            start = n;
        }
        
        public void printAll()
        {
            start.printMig();
        }

    }
    class Node
    {
        public Node next;
        public int tal;
        
        public void printMig()
        {
            if(next != null) next.printMig();
            Console.WriteLine(tal);
        }
    }
    
}