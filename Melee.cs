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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace LegendofGnome
{
    class Melee
    {
        private Canvas canvas;
        public Rectangle sword = new Rectangle();
        public bool hit;

        public Melee(Canvas c, Window window, Point Point)
        {
            sword.Height = 20;
            sword.Width = 20;
            //BitmapImage bitmapBackground = new BitmapImage(new Uri("Fireball Projectile.png", UriKind.Relative));
            //ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            sword.Fill = Brushes.Gray; //backgroundBrush;
            canvas.Children.Add(sword);
            double direction_x = Mouse.GetPosition(window).X;
            double direction_y = Mouse.GetPosition(window).Y;
            if (direction_x <= 0)
            {
                Canvas.SetLeft(this.sword, Point.X + 25);
            }
            Canvas.SetTop(this.sword, Point.Y + 25);
        }

        public bool checkCollision(Point source)
        {
            for (int i = 0; i < canvas.Children.Count; i++)
            {
                if (canvas.Children[0].GetType() == typeof(System.Windows.Shapes.Rectangle))
                {

                }
                if (source.X <= Canvas.GetLeft(canvas.Children[0]) & source.X >= Canvas.GetLeft(canvas.Children[0]) + canvas.Children[0].)
                {

                }
            }
            return hit;
        }
    }
}
