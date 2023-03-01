using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _022423_GraphWPF
{
    public class Vertex
    {
        public string name;
        public double xpos;
        public double ypos;
        public Vertex next;
        public Rectangle rect;
        public TextBlock text;
        public Vertex()
        { 
        }
    }
}
