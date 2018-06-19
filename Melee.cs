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
        private Window window;
        public Rectangle sword = new Rectangle();
        public bool hit;

        public Melee(Canvas c, Window w, Point Point)
        {
            canvas = c;
            window = w;
            sword.Height = 20;
            sword.Width = 20;
            //BitmapImage bitmapBackground = new BitmapImage(new Uri("Fireball Projectile.png", UriKind.Relative));
            //ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            sword.Fill = Brushes.Gray; //backgroundBrush;
            canvas.Children.Add(sword);
            double direction_x = Mouse.GetPosition(window).X - Point.X;
            double direction_y = Mouse.GetPosition(window).Y - Point.Y;
            if (direction_x > 0)
            {
                Canvas.SetLeft(this.sword, Point.X + 50);
            }
            if (direction_x < 0)
            {
                Canvas.SetLeft(this.sword, Point.X - 20);
            }
            if (direction_y > 0)
            {
                Canvas.SetTop(this.sword, Point.Y + 50);
            }
            if (direction_y < 0)
            {
                Canvas.SetTop(this.sword, Point.Y - 20);
            }
        }

        public bool checkCollision(Point t, Point s, Rectangle target, Rectangle source)
        {
            bool temp = false;

            if (t.X <= s.X + source.Width & t.Y <= s.Y + source.Height)
            {
                if (t.X + target.Width >= s.X & t.Y + target.Height >= s.Y)
                {
                    temp = true;
                }
            }
            return temp;
        }
    }
}
