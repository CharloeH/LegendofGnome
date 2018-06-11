using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Map
    {


        public Point doorPoint = new Point(600, 0);
        public Rectangle door1 = new Rectangle();
        public void DoorGenerate(Rectangle door1, Canvas canvas)
        {
            door1.Height = 50;
            door1.Width = 50;
            
            canvas.Children.Add(door1);
            Canvas.SetLeft(door1, doorPoint.X);
            Canvas.SetTop(door1, doorPoint.Y);
            door1.Fill = Brushes.Green;
        }
        }
}
