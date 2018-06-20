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
    class Boss
    {
        public Rectangle bossRectangle;
        public int attackAnimation;
        public Rectangle bossSword;
        public Point bossPoint = new Point(300,300);
        int swordLength = 300;
        int swordWidth = 50;
        Canvas canvas;
        Window window;

        public Boss(Canvas c, Window w)
        {
            canvas = c;
            window = w;
        }

        public void spawnBoss()
        {
            bossRectangle = new Rectangle();
            bossSword = new Rectangle();
            bossRectangle.Height = 100;
            bossRectangle.Width = 100;
            bossRectangle.Fill = Brushes.Magenta;
            canvas.Children.Add(bossRectangle);
            bossSword.Height = swordLength;
            bossSword.Width = swordWidth;
            bossSword.Fill = Brushes.Silver;
            Canvas.SetLeft(bossRectangle, 300);
            Canvas.SetTop(bossRectangle, 300);
            Canvas.SetLeft(bossSword, bossPoint.X + 10);
            Canvas.SetTop(bossSword, bossPoint.Y - 5);
        }

        public void attack()
        {
            if (attackAnimation == 4)
            {
                bossRectangle.Width = swordWidth;
                bossRectangle.Height = swordLength;
                Canvas.SetLeft(bossSword, bossPoint.X + 50 - swordWidth);
                Canvas.SetTop(bossSword, bossPoint.Y - 20 - swordLength);
            }
            if (attackAnimation == 3)
            {
                bossRectangle.Width = swordLength;
                bossRectangle.Height = swordWidth;
                Canvas.SetLeft(bossSword, bossPoint.X - 20 - swordLength);
                Canvas.SetTop(bossSword, bossPoint.Y + 50 + swordWidth);
            }
            if (attackAnimation == 2)
            {
                bossRectangle.Width = swordWidth;
                bossRectangle.Height = swordLength;
                Canvas.SetLeft(bossSword, bossPoint.X + 50 + swordWidth);
                Canvas.SetTop(bossSword, bossPoint.Y + 100 + swordLength);
            }
            if (attackAnimation == 1)
            {
                bossRectangle.Width = swordLength;
                bossRectangle.Height = swordWidth;
                Canvas.SetLeft(bossSword, bossPoint.X + 100 + swordLength);
                Canvas.SetTop(bossSword, bossPoint.Y + 50 + swordWidth);
            }
            attackAnimation--;
        }

        public void kill()
        {
            canvas.Children.Remove(bossRectangle);
        }
    }
}
