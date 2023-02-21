using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_med_Canvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double xpos = 20;
        double ypos = 20;
        double width = 50;
        double height = 50;

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            xpos += 20;
            tegnFirkant(xpos, ypos, width, height);
            tegnText(myTextBox.Text, xpos + 5, ypos + 5);
            tegnPil(xpos + width, ypos + height / 2, xpos + 100, ypos + height / 2);

            Node n = new Node();
            
        }
        
        
        
        public class Node
        {
            public Node next;
            double xpos = 20;
            double ypos = 20;
            double width = 50;
            double height = 50;
            public Node()
            {
                
            }
            
        }

        private void tegnFirkant(double xStart, double yStart, double width, double height)
        {
            Rectangle rect1 = new Rectangle();
            rect1.Stroke = new SolidColorBrush(Colors.Black);

            rect1.StrokeThickness = 2;
            rect1.Width = width;
            rect1.Height = height;
            Canvas.SetLeft(rect1, xStart);
            Canvas.SetTop(rect1, yStart);
            myCanvas.Children.Add(rect1);
        }

        private void tegnPil(double xStart, double yStart, double xEnd, double yEnd)
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

        private void clearCanvas()
        {
            myCanvas.Children.Clear();
        }
    }

}
