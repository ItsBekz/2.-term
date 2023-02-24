using System.Collections;

namespace _022223_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myList = new MyLinkedList();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add();
            

            myList.printAll();
            Console.WriteLine("--------ForEach--------------");


            foreach (Node item in myList)
            {
                Console.WriteLine(item.value);
            }
        }
    }

    class MyLinkedList : IEnumerator, IEnumerable
    {
        int pos = -1;
        Node current;

        public Node start;
        public void Add(int val)
        {
            Node n = new Node();
            n.value = val;
            n.next = start;
            start = n;
        }
        public void printAll()
        {
            start.print();
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current { get { return current; } }

        public bool MoveNext()
        {
            if (pos == -1)
            {
                current = start;
                pos++;
                return true;
            }
            if (current.next != null)
            {
                current = current.next;
                pos++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            pos = -1;
        }
    }

    class House
    {
        string name;
        public House(string name)
        {
            this.name = name;
        }
    }

    class Node
    {   
        public Node next;
        public int value;
        public void print()
        {
            if (next != null)
                next.print();
            Console.WriteLine(value);
        }
    }

}
