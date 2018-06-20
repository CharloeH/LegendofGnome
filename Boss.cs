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
        int swordWidth = 100;
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
            canvas.Children.Add(bossSword);
            bossSword.Height = swordWidth;
            bossSword.Width = swordLength;
            bossSword.Fill = Brushes.Silver;
            Canvas.SetLeft(bossRectangle, 350);
            Canvas.SetTop(bossRectangle, 350);
            Canvas.SetLeft(bossSword, bossPoint.X + 10);
            Canvas.SetTop(bossSword, bossPoint.Y - 5);
        }

        public bool attack(Point playerPoint, Rectangle playerRectangle)
        {
            //sets the boss to be right in front of you
            bossPoint.X = playerPoint.X - 300;
            bossPoint.Y = playerPoint.Y + 20;
            Canvas.SetLeft(bossRectangle, bossPoint.X);
            Canvas.SetTop(bossRectangle, bossPoint.Y);
            Canvas.SetLeft(bossSword, bossPoint.X + 10);
            Canvas.SetTop(bossSword, bossPoint.Y - 25);
            //if (checkCollision(playerPoint, playerRectangle))
            //{
            //    temp = true;
            //}
            return true;
        }

        public void youLeftTheRoom()
        {
            canvas.Children.Remove(bossRectangle);
            canvas.Children.Remove(bossSword);
        }

        //public bool checkCollision(Point s, Rectangle source)
        //{
        //    bool temp = false;

        //    if (bossPoint.X + 10 <= s.X + source.Width & bossPoint.Y + 10 <= s.Y + source.Height)
        //    {
        //        if (bossPoint.X - 25 + swordLength >= s.X & bossPoint.Y - 25 + swordWidth >= s.Y)
        //        {
        //            temp = true;
        //            MessageBox.Show("test");
        //        }
        //    }
        //    return temp;
        //}
    }
}
