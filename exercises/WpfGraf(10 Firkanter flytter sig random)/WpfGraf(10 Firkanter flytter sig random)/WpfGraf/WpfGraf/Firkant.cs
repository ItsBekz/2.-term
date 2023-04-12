using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraf
{
    class Firkant
    {
        Point p = new Point(200,200);
        int width = 0;
        int height = 0;
        Random rand = new Random();
        public  Firkant(int canvasWidth, int canvasHeight) 
        { 
            width = canvasWidth;
            height = canvasHeight;
            flytMigHeleTiden();
        }
        void flytMigHeleTiden()
        {
            Task.Run(async () =>
            {
                for (int i = 0; i < 1000; i++)               
                { 
                    flytEtStep(); 
                    await Task.Delay(100); 
                }
            });
        }
        
        private void flytEtStep()
        {
            p.X += rand.Next(-5, 6);
            p.Y += rand.Next(-5, 6);

            //---Sørge for at jeg ikke går ud af skærmen----
            if(p.X < 0 )
                p.X = 0;
            else if(p.X> width) 
                p.X = width;
            else if (p.Y < 0)
                p.Y = 0;
            else if (p.Y > height)
                p.Y = height;
        }
        public Point getPoint()
        {
            return p; 
        }

    }
}
