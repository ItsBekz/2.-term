
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
            tree.printTree();
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

        public void printTree()
        {
            Stack stack = new Stack();
            stack.Push(root);
            object o = stack.Pop();
            while(o != null)
            {
                Node n = (Node)o;
                Console.WriteLine(n.value);
                o = stack.Pop();
            }
        }
    }
}