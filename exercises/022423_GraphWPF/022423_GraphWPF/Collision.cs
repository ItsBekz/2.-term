using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace _022423_GraphWPF
{
    public class Collision
    {
        public static bool checkCollision(Vertex vrtx)
        {
            bool check = false;
            Point p = Mouse.GetPosition(Application.Current.MainWindow);
            if (p.X > vrtx.xpos && p.X < vrtx.xpos + vrtx.width && p.Y > vrtx.ypos && p.Y < vrtx.ypos + vrtx.height)
            {
                check = true;
            }
            return check;
        }
    }
}
