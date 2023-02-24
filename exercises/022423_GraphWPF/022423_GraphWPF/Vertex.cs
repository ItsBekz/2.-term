using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _022423_GraphWPF
{
    public class Vertex
    {
        public List<Edge> edges;
        public string name;
        public double xpos;
        public double ypos;
        public double width;
        public double height;
        public Vertex(string name, double xpos, double ypos, double width, double height)
        {
            this.name = name;
            this.xpos = xpos;
            this.ypos = ypos;
            this.width = width;
            this.height = height;
            //edges = new List<Edge>();
        }
        public void addEdge(Vertex next, int weight)
        {
            Edge edge = new Edge();
            edge.next = next;
            edge.prev = this;
            edge.weight = weight;
            edges.Add(edge);
        }
    }
}
