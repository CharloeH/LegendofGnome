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
    class Projectile
    {
        public bool isArrow = false;
        public int i = 1;
        public int counter = 1;
        public Cursor LOLHand;
        public double Click_X;
        public double Click_Y;
        public double slope_X;
        public double slope_Y;
        public Rectangle[] arrows = new Rectangle[20];
        public Array[] arrowXCords = new Array[20];
        public Array[] arrowYcords = new Array[20];
        public Point arrow_pos = new Point(0, 0);
        public Projectile()
        {
            FileStream fileStream;//set cursor
            fileStream = new FileStream("LOLHand.cur", FileMode.Open);
            LOLHand = new Cursor(fileStream);
        }
        public void shoot(Canvas canvas, Point playerPoint)
        {
            while (i < counter)
            {
                arrows[i] = new Rectangle();
                arrows[i].Height = 35;
                arrows[i].Width = 9;
                arrows[i].Fill = Brushes.Black;
                canvas.Children.Add(arrows[i]);
                arrow_pos.X = playerPoint.X + 25;
                arrow_pos.Y = playerPoint.Y + 25;
                Canvas.SetLeft(arrows[i], arrow_pos.X);
                Canvas.SetTop(arrows[i], arrow_pos.Y);
                i++;
                isArrow = true;
            }
        }

        public void FindSlope(Window window, Point playerPoint)
        {
            double player_X = playerPoint.X;
            double player_Y = playerPoint.Y;

            Click_X = Mouse.GetPosition(window).X;
            Click_Y = Mouse.GetPosition(window).Y;
            //MessageBox.Show(Click_X.ToString() + " " + Click_Y.ToString());

            slope_Y = (player_Y - Click_Y);
            slope_X = (player_X - Click_X);
            //MessageBox.Show(slope_Y.ToString() + " " + slope_X.ToString());
        }

        public void Move(Canvas canvas)
        {
            if (isArrow == true)
            {
                arrow_pos.X = arrow_pos.X - (slope_X / 50);
                Console.WriteLine(arrow_pos.X);
                Canvas.SetLeft(arrows[i], arrow_pos.X);
                arrow_pos.Y = arrow_pos.Y - (slope_Y / 50);
                Canvas.SetTop(arrows[i], arrow_pos.Y);
                //Console.WriteLine(arrow_pos.Y);
            }
        }
    }
}
