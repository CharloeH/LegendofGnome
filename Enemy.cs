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
    class Enemy
    {
        public int attackCounter = 0;
        public int health;
        Rectangle enemyRectangle = new Rectangle();
        public Canvas canvas;
        public Enemy(Canvas c, Point EnemyPoint)
        {
            canvas = c;
            Canvas.SetTop(enemyRectangle, EnemyPoint.Y);
            Canvas.SetLeft(enemyRectangle, EnemyPoint.X);
            enemyRectangle.Height = 50;
            enemyRectangle.Width = 50;
            enemyRectangle.Fill = Brushes.Red;
            canvas.Children.Add(enemyRectangle);
            health = 10;
        }

        public Point Move(Point playerPoint, Point enemyPoint)
        {
            if (enemyPoint.X <= playerPoint.X || enemyPoint.X >= playerPoint.X || enemyPoint.Y <= playerPoint.Y || enemyPoint.Y >= playerPoint.Y)
            {
                if (enemyPoint.X <= playerPoint.X)
                {
                    enemyPoint.X += 5;
                }
                if (enemyPoint.X >= playerPoint.X)
                {
                    enemyPoint.X -= 5;
                }
                if (enemyPoint.Y >= playerPoint.Y)
                {
                    enemyPoint.Y -= 5;
                }
                if (enemyPoint.Y <= playerPoint.Y)
                {
                    enemyPoint.Y += 5;
                }
                if ((enemyPoint.Y - playerPoint.Y == 20 || enemyPoint.Y - playerPoint.Y == -20) & (enemyPoint.X - playerPoint.Y == 20 || enemyPoint.X - playerPoint.X == -20))
                {
                    attackCounter++;
                    if (attackCounter == 30)
                    {
                        MessageBox.Show("Tag! You're it!");
                        attackCounter = 0;
                    }
                }
                else
                {
                    attackCounter = 0;
                }
            }
            Canvas.SetLeft(enemyRectangle, enemyPoint.X);
            Canvas.SetTop(enemyRectangle, enemyPoint.Y);
            return enemyPoint;
        }

        public void attack(int direction)
        {
            //Melee melee = new Melee(canvas);
        }

        public void hit()
        {
            health--;
            if (health == 0)
            {
                canvas.Children.Remove(this.enemyRectangle);
            }
        }
    }
}
