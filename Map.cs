using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Map
    {

        public Random mapRandom = new Random();
        public Point doorPoint = new Point(600, 0);
        public Rectangle door1 = new Rectangle();
        public int temp;
        public void backgroundGenerate(Canvas canvas)
        {
            Rectangle background = new Rectangle();
        background.Height = 800;
            background.Width = 1000;

            BitmapImage bitmapBackground = new BitmapImage(new Uri("Dungeon.png", UriKind.Relative));
        ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
        background.Fill = backgroundBrush;
            canvas.Children.Add(background);

        }
    public void DoorGenerate(Rectangle door1, Canvas canvas)
        {
            door1.Height = 50;
            door1.Width = 50;
            canvas.Children.Add(door1);

        }
        public void mapGenerate(Canvas canvas)
        {
            
            temp = mapRandom.Next(5);
            if (temp == 1)
            {
                doorPoint.X = 0;
                doorPoint.Y = 350;
                
                Canvas.SetLeft(door1, doorPoint.X);
                Canvas.SetTop(door1, doorPoint.Y);
                door1.Fill = Brushes.Red;
            }
            if(temp == 2)
            {
                doorPoint.X = 950;
                doorPoint.Y = 350;
                
                
                Canvas.SetLeft(door1, doorPoint.X);
                Canvas.SetTop(door1, doorPoint.Y);
                door1.Fill = Brushes.Green;
            }
            if(temp == 3)
            {
                doorPoint.X = 450;
                doorPoint.Y = 0;
               

                
                Canvas.SetLeft(door1, doorPoint.X);
                Canvas.SetTop(door1, doorPoint.Y);
                door1.Fill = Brushes.Blue;
            }
            if(temp == 4)
            {
                doorPoint.X = 450;
                doorPoint.Y = 750;
                
                Canvas.SetLeft(door1, doorPoint.X);
                Canvas.SetTop(door1, doorPoint.Y);
                door1.Fill = Brushes.Purple;
            }

        }
        }
}
