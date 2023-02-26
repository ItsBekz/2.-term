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
        public static List<Line> lines = new List<Line>();
        public static List<Polygon> arrows = new List<Polygon>();
        public Vertex next;
        public Vertex prev;
        public string weight;

        public Edge(Vertex prev, Vertex next, string weight)
        {
            this.prev = prev;
            this.next = next;
            this.weight = weight;
            //DrawArrow(prev.xpos, prev.ypos, next.xpos, next.ypos);
        }

        private void CreateArrow(double xStart, double yStart, double xEnd, double yEnd)
        {
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = xStart;
            line.Y1 = yStart;
            line.X2 = xEnd;
            line.Y2 = yEnd;

            double angle = Math.Atan2(line.Y2 - line.Y1, line.X2 - line.X1);
            double arrowLength = 10;
            double arrowAngle = Math.PI / 6; // 30 degrees in radians

            Polygon arrowhead = new Polygon();
            arrowhead.Stroke = Brushes.Black;
            arrowhead.Fill = Brushes.Black;
            arrowhead.Points = new PointCollection();
            arrowhead.Points.Add(new Point(line.X2, line.Y2));
            arrowhead.Points.Add(new Point(
                line.X2 - arrowLength * Math.Cos(angle + arrowAngle),
                line.Y2 - arrowLength * Math.Sin(angle + arrowAngle)));
            arrowhead.Points.Add(new Point(
                line.X2 - arrowLength * Math.Cos(angle - arrowAngle),
                line.Y2 - arrowLength * Math.Sin(angle - arrowAngle)));
            Canvas.SetZIndex(arrowhead, 1); // Make sure arrowhead appears on top of line
            lines.Add(line);
            arrows.Add(arrowhead);
        }
    }
}
