using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
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


namespace _032023_TaskGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            startSetup();
        }
        public void startSetup()
        {
            Car car1 = new Car("car1.png", myCanvas);
        }

    }
    class Car
    {
        int x = 0;
        int y = 0;
        Canvas myCanvas;
        Image myImage;
        public Car(String fileName, Canvas mc)
        {
            myCanvas = mc;
            myImage = new Image();
            loadImage(fileName, 100);
            myCanvas.Children.Add(myImage);
            Canvas.SetLeft(myImage, x);
            Canvas.SetTop(myImage, y);
            Thread t1 = new Thread(flytCarTilHøjre);
            t1.Start();
        }
        public void flytCarTilHøjre()
        {
            for (int i = 0; i < 100; i++)
            {
                x += 5;
                moveCar();
                Thread.Sleep(100);
            }


        }
        public void moveCar()
        {
            myCanvas.Dispatcher.Invoke(() =>
            {

                Canvas.SetLeft(myImage, x);
                Canvas.SetTop(myImage, y);
            });
        }
        public void loadImage(String imageName, int imgWidth)
        {
            myImage.Width = imgWidth;
            // Create source
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();

            myBitmapImage.UriSource = new Uri("pack://application:,,,/images/" + imageName);

            myBitmapImage.DecodePixelWidth = imgWidth;
            myBitmapImage.EndInit();
            myImage.Source = myBitmapImage;
            //    myImage.Opacity = 0.70;
        }
    }

}

