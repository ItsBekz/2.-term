using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace WpfGraf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int canvasWidth = 500;
        int canvasHeight = 500;
        List<Firkant> listeMedFirkanter = new List<Firkant>();

        public MainWindow()
        {
            InitializeComponent();
            clearCanvas();
            lavFlereFirkanter();
            tegnAlleHeleTiden();
        }

        private void lavFlereFirkanter()
        {
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
            listeMedFirkanter.Add(new Firkant(canvasWidth, canvasHeight));
        }
        private void tegnAlleHeleTiden()
        {

            Task.Run(async () =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    tegnAlleFirkanterEnGang();
                    await Task.Delay(50);
                }
            });
        }
        private void tegnAlleFirkanterEnGang()
        {
            this.Dispatcher.Invoke(() =>
            {
                clearCanvas();
                foreach (Firkant firkant in listeMedFirkanter)
                {

                    System.Drawing.Point p = firkant.getPoint();

                    tegnFikant(p.X, p.Y, 10, 10);
                }
            });
        }
        private void clearCanvas()
        {
            mitCanvas.Children.Clear();
        }
        private void tegnFikant(double xStart, double yStart, double width, double height)
        {
            Rectangle rect1 = new Rectangle();
            rect1.Stroke = new SolidColorBrush(Colors.Black);

            rect1.StrokeThickness = 2;
            rect1.Width = width;
            rect1.Height = height;
            Canvas.SetLeft(rect1, xStart);
            Canvas.SetTop(rect1, yStart);
            mitCanvas.Children.Add(rect1);
        }
        private void tegnText(String txt, double xStart, double yStart)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = txt;
            textBlock.FontSize = 24;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, xStart);
            Canvas.SetTop(textBlock, yStart);
            mitCanvas.Children.Add(textBlock);
        }

        private void mitCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clearCanvas();
            Point p = e.GetPosition((Canvas)sender);
            Console.WriteLine(p.X + " " + p.Y);
            // tegnFikant(p.X, p.Y, width, height);         

        }
    }
}
