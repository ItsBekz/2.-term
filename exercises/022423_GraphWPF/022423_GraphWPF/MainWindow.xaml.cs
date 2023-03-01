using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _022423_GraphWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double width = 50;
        double height = 50;
        Graph graph = new Graph();
        public Vertex target1, target2;

        public MainWindow()
        {
            InitializeComponent();
            clearCanvas();
        }
        private void clearCanvas()
        {
            myCanvas.Children.Clear();
        }
        
        
        private Rectangle DrawRectangle(double xStart, double yStart, double width, double height)
        {
            
            Rectangle rect1 = new Rectangle();
            rect1.Stroke = new SolidColorBrush(Colors.Black);

            rect1.StrokeThickness = 2;
            rect1.Width = width;
            rect1.Height = height;
            Canvas.SetLeft(rect1, xStart);
            Canvas.SetTop(rect1, yStart);
            //myCanvas.Children.Add(rect1);
            return rect1;
            //rectangles.Add(rect1);
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
            Arrow a = new Arrow();
            a.line = line;
            a.arrowHead = arrowhead;
            graph.arrows.Add(a);
        }
        
        
        private TextBlock DrawText(String txt, double xStart, double yStart)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = txt;
            textBlock.FontSize = 24;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, xStart);
            Canvas.SetTop(textBlock, yStart);
            //myCanvas.Children.Add(textBlock);
            return textBlock;
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clearCanvas();
            Point p = Mouse.GetPosition(myCanvas);

            if(target1 != null && target2 != null)
            {
                target1 = null;
                target2 = null;
            }

            //SelectVertex();
            if (vrtxName.Text == "")
            {
                foreach (Vertex vrtx in graph.list)
                {
                    if (Collision(vrtx))
                    {
                        if(target1 == null)
                        {
                            target1 = vrtx;
                            target1.rect.Stroke = new SolidColorBrush(Colors.Red);
                        }
                        else
                        { 
                            target2 = vrtx;
                            target2.rect.Stroke = new SolidColorBrush(Colors.Red);
                        }
                    }
                    else
                    {
                        if (target1 != vrtx && target2 != vrtx)
                        {
                            vrtx.rect.Stroke = new SolidColorBrush(Colors.Black);
                        } 
                    }
                }
            }
            else
            {
                Vertex v = new Vertex();
                v.xpos = p.X;
                v.ypos = p.Y;
                v.name = vrtxName.Text;
                v.rect = DrawRectangle(v.xpos, v.ypos, width, height);
                v.text = DrawText(v.name, v.xpos + 5, v.ypos + 5);

                graph.list.Add(v);
            }
            if(target1 != null && target2 != null)
            {
                CreateArrow(target1.xpos, target1.ypos, target2.xpos, target2.ypos);
            }
            vrtxName.Text = "";


            foreach (Vertex vrtx in graph.list)
            {
                myCanvas.Children.Add(vrtx.rect);
                myCanvas.Children.Add(vrtx.text);
            }
            foreach(Arrow a in graph.arrows)
            {
                myCanvas.Children.Add(a.line);
                myCanvas.Children.Add(a.arrowHead);
            }
        }
        
        public bool Collision(Vertex vrtx)
        {
            bool check = false;
            Point p = Mouse.GetPosition(myCanvas);
            if ((p.X > vrtx.xpos && p.X < vrtx.xpos + width) && (p.Y > vrtx.ypos && p.Y < vrtx.ypos + height))
            {
                check = true;
            }
            return check;
        }

    }
}
