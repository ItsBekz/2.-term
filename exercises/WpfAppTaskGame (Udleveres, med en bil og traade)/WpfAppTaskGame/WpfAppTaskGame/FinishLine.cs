using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfAppTaskGame
{
    public class FinishLine 
    {
        public Image myImage;
        public int placement;
        public int x;
        public int y;
        public Canvas myCanvas { get; set; }
        public FinishLine(String fileName, Canvas mc)
        {
            x = 300;
            y = 70;
            myCanvas = mc;
            myImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/images/" + fileName);
            bitmap.Rotation = Rotation.Rotate90;
            bitmap.EndInit();
            myImage.Width = 100;
            myImage.Height = 250;
            myImage.Source = bitmap;
            Canvas.SetLeft(myImage, x);
            Canvas.SetTop(myImage, y);
            myCanvas.Children.Add(myImage);

        }
    }
}
