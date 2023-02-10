
using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace _020923_temp3merge_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.root = new Node() { value = 10 };
            tree.root.left = new Node() { value = 5 };
            tree.root.right = new Node() { value = 15 };
            tree.root.left.left = new Node() { value = 1 };
            tree.root.left.right = new Node() { value = 7 };
            tree.root.right.right = new Node() { value = 20 };
            tree.root.right.left = new Node() { value = 12 };
            tree.printTree2();
            tree.Search(2);
        }
    }

    public class Node
    {
        public Node left;
        public Node right;
        public int value;
    }

    public class Tree
    {
        public Node root;
        public int level = 1;

        public void printTree()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count() > 0)
            {
                Node n = queue.Dequeue();
                if (n.left != null)
                    queue.Enqueue(n.left);
                if (n.right != null)
                    queue.Enqueue(n.right);
                Console.WriteLine(n.value);
            }
        }

        public void printTree2()
        {
            Stack<Node> stackPrimary = new Stack<Node>();
            Stack<Node> stackSecond = new Stack<Node>();
            stackPrimary.Push(root);

            while (stackPrimary.Count > 0)
            {
                Console.WriteLine("Level " + level);
                while (stackPrimary.Count > 0)
                {
                    Node n = stackPrimary.Pop();
                    Console.WriteLine(n.value);
                    if (n.left != null)
                        stackSecond.Push(n.left);
                    if (n.right != null)
                        stackSecond.Push(n.right);
                }
                level++;
                stackPrimary = stackSecond;
                stackSecond = new Stack<Node>();
            }
        }

        public bool Search(int i)
        {
            Node n = new Node();
            if(i == n.value)
            {
                
            }
            return 
        }
    }
}