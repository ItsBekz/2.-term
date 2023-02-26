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
        public static List<Edge> edges = new List<Edge>(); // keeps track of all edges made
        public static List<Rectangle> rectangles = new List<Rectangle>(); // keeps track of all rectangles made
        public static List<TextBlock> textBlocks = new List<TextBlock>(); // keeps track of all textblocks made
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
            CreateRectangle(xpos, ypos, width, height, name); // creates the rectangle and adds the rectangle to the list of rectangles
            CreateText(name, xpos, ypos); // creates the textblock for the vertex and adds the textblock to the list of textblocks
        }
        public static void CreateEdge(Vertex prev, Vertex next, string weight) 
        {
            Edge edge = new Edge(prev, next, weight);
            edge.prev = prev;
            edge.next = next;
            edge.weight = weight;
            edges.Add(edge);
        }
        
        public void CreateRectangle(double xpos, double ypos, double width, double height, string name)
        {
            Rectangle rect1 = new Rectangle() { Name = name };
            rect1.Stroke = new SolidColorBrush(Colors.Black);

            rect1.StrokeThickness = 2;
            rect1.Width = width;
            rect1.Height = height;
            Canvas.SetLeft(rect1, xpos);
            Canvas.SetTop(rect1, ypos);
            rectangles.Add(rect1);
        }

        public void CreateText(string txt, double xpos, double ypos)
        {
            TextBlock tb = new TextBlock();
            tb.Text = txt;
            tb.FontSize = 24;
            tb.Foreground = Brushes.Black;
            Canvas.SetLeft(tb, xpos + 5);
            Canvas.SetTop(tb, ypos + 5);
            textBlocks.Add(tb);
        }
    }
}
