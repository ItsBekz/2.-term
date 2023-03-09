using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace _022423_GraphWPF
{
    public class Edge
    {
        public static List<Arrow> arrows = new List<Arrow>();
        public Vertex next;
        public Vertex prev;
        public string weight;

        public Edge(Vertex prev, Vertex next, string weight)
        {
            this.prev = prev;
            this.next = next;
            this.weight = weight;
        }
    }
}
