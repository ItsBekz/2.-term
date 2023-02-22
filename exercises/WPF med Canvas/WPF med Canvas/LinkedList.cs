using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_med_Canvas
{
    public class LinkedList
    {

        public LinkedList()
        {
            Node n = new Node();
        }

        public void AddNode(int value)
        {
            Node n = new Node();
            n.value = value;
            n.next = null;
        }
        
        public void FindNode(int value)
        {
            
        }
        
        public void RemoveNode(int value)
        {
            
        }
    }
}
