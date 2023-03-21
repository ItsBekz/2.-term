using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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


namespace WpfAppTaskGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        int placement = 1;
        Random rand = new Random();
        public static List<Task> TaskList;
        public static FinishLine finishLine;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void startSetup()
        {
            Car car1 = new Car("car1.png", myCanvas, 70, rand.Next(1, 7));           
            Car car2 = new Car("car2.png", myCanvas, 120, rand.Next(1, 7));           
            Car car3 = new Car("car3.png", myCanvas, 170, rand.Next(1, 7));           
            Car car4 = new Car("car4.png", myCanvas, 220, rand.Next(1, 7));           
            Car car5 = new Car("car5.png", myCanvas, 270, rand.Next(1, 7));
            finishLine = new FinishLine("finishLine.png", myCanvas);

            TaskList = new List<Task>
            {
                Task.Run(() => car1.flytCarTilHøjre()),
                Task.Run(() => car2.flytCarTilHøjre()),
                Task.Run(() => car3.flytCarTilHøjre()),
                Task.Run(() => car4.flytCarTilHøjre()),
                Task.Run(() => car5.flytCarTilHøjre())
            };

        }

        private void Btn_NewGame_Click(object sender, RoutedEventArgs e)
        {
            startSetup();
        }

        

    }
    public class Car
    {
        int x = 0;
        int y = 0;
        int speed;
        Canvas myCanvas;
        Image myImage; 
        public Car(String fileName, Canvas mc, int y, int spd) 
        {
            this.y = y;
            speed = spd;
            myCanvas = mc;
            myImage = new Image();
            loadImage( fileName, 100);
            myCanvas.Children.Add(myImage);
            Canvas.SetLeft(myImage, x);
            Canvas.SetTop(myImage, this.y);
        }
        public async void flytCarTilHøjre()
        {
            for (int i = 0; i < 100; i++)
            {
                x += speed;
                moveCar();

                if (x + myImage.Width >= MainWindow.finishLine.x)
                {
                    MainWindow.finishLine.placement++;
                    int place = MainWindow.finishLine.placement;

                    foreach(Task task in MainWindow.TaskList)
                    {
                        if(task.Id == Task.CurrentId)
                        {
                            task.Dispose();
                            break;
                        }
                    }
                    TextBox textBox = new TextBox();
                    textBox.Text = place.ToString();
                    textBox.FontSize = 24;
                    textBox.Background = Brushes.White;
                    textBox.BorderBrush = Brushes.Black;
                    textBox.BorderThickness = new Thickness(2);
                    myCanvas.Children.Add(textBox);
                    Canvas.SetLeft(textBox, x - 30);
                    Canvas.SetTop(textBox, y + 30);

                    break;
                }

                await Task.Delay(100);
            }
         

        }
        public void moveCar ()
        {
            myCanvas.Dispatcher.Invoke(() =>
            {
                Canvas.SetLeft(myImage, x);
                Canvas.SetTop(myImage, y);
            });
        }
        public void loadImage( String imageName, int imgWidth)
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

