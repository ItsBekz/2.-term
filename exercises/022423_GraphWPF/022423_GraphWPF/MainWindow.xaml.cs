using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        List<Vertex> list = new List<Vertex>();
        public static Object target1, target2;

        public MainWindow()
        {
            InitializeComponent();
            clearCanvas();
        }
        private void clearCanvas()
        {
            myCanvas.Children.Clear();
        }
        
        /*
        private void tegnFikant(double xStart, double yStart, double width, double height)
        {
            Rectangle rect1 = new Rectangle();
            rect1.Stroke = new SolidColorBrush(Colors.Black);

            rect1.StrokeThickness = 2;
            rect1.Width = width;
            rect1.Height = height;
            Canvas.SetLeft(rect1, xStart);
            Canvas.SetTop(rect1, yStart);
            myCanvas.Children.Add(rect1);
            //rectangles.Add(rect1);
        }
        */
        
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
            myCanvas.Children.Add(line);
            myCanvas.Children.Add(arrowhead);
        }
        
        /*
        private void tegnText(String txt, double xStart, double yStart)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = txt;
            textBlock.FontSize = 24;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, xStart);
            Canvas.SetTop(textBlock, yStart);
            myCanvas.Children.Add(textBlock);
        }
        */
        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clearCanvas();
            if (target1 != null && target2 != null)
            {
                target1 = null;
                target2 = null;
            }
            try 
            {
                SelectVertex();
                vrtxName.Text = "";
                Print();
            }
            catch 
            {
                MessageBox.Show("Type a letter instead of a number.");
            }
            
        }

        private void SelectVertex()
        {
            Point p = Mouse.GetPosition(myCanvas);
            if (vrtxName.Text == "")
            {
                foreach (Vertex vrtx in list)
                {
                    int index = list.IndexOf(vrtx);
                    if ((p.X > vrtx.xpos && p.X < vrtx.xpos + vrtx.width) && (p.Y > vrtx.ypos && p.Y < vrtx.ypos + vrtx.height))
                    {
                        if (target1 == null)
                        {
                            target1 = Vertex.rectangles[index];
                            Vertex.rectangles[index].Stroke = new SolidColorBrush(Colors.Red);
                            Vertex.textBlocks[index].Foreground = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            target2 = Vertex.rectangles[index];
                            Vertex.rectangles[index].Stroke = new SolidColorBrush(Colors.Red);
                            Vertex.textBlocks[index].Foreground = new SolidColorBrush(Colors.Red);
                        }
                    }
                    else
                    {
                        Vertex.rectangles[index].Stroke = new SolidColorBrush(Colors.Black);
                        Vertex.textBlocks[index].Foreground = new SolidColorBrush(Colors.Black);
                    }

                    if (edgeWeight.Text != "")
                    {

                    }
                }
            }
            else
            {
                CreateVertex();
            }
            //DrawArrow(p.X + width, p.Y + height / 2, p.X + 100, p.Y + height / 2);
        }

        private void CreateVertex()
        {
            Vertex vrtx = new Vertex(vrtxName.Text, p.X, p.Y, width, height);
            list.Add(vrtx);
        }

        private void Print()
        {
            foreach (Vertex vrtx in list)
            {
                myCanvas.Children.Add(Vertex.rectangles[list.IndexOf(vrtx)]);
                myCanvas.Children.Add(Vertex.textBlocks[list.IndexOf(vrtx)]);
            }
        }
    }
}
