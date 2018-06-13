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
        
        
        public double Enemy_posY;
        public double Enemy_posX;
        Rectangle enemyRectangle = new Rectangle();
        public void enemyGenerate(Canvas canvas, Point EnemyPoint)
        {
            Canvas.SetTop(enemyRectangle, EnemyPoint.Y);
            Canvas.SetLeft(enemyRectangle, EnemyPoint.X);
            enemyRectangle.Height = 50;
            enemyRectangle.Width = 50;
            enemyRectangle.Fill = Brushes.Red;
            canvas.Children.Add(enemyRectangle);
           
        }
        public Point enemyMove(Point playerPoint, Canvas canvas, Point enemyPoint)
        {
            Enemy_posX  = enemyPoint.X;
            Enemy_posY = enemyPoint.Y; ;
            if (enemyPoint.X <= playerPoint.X)
            {
                enemyPoint.X += 5;
                if(enemyPoint.Y - playerPoint.Y == 20 || enemyPoint.Y - playerPoint.Y == -20)
                {
                    MessageBox.Show("ha!");
                }
                
            }
            if(enemyPoint.X >= playerPoint.X)
            {
                enemyPoint.X -= 5;
            }
            if(enemyPoint.Y >= playerPoint.Y)
            {
                enemyPoint.Y -= 5;
            }
            if(enemyPoint.Y <= playerPoint.Y)
            {
                enemyPoint.Y += 5;
            }
            Update(canvas, enemyPoint);
            return enemyPoint;
           
        }
        public void Update(Canvas canvas, Point enemyPoint)
        {
            Canvas.SetLeft(enemyRectangle, enemyPoint.X);
            Canvas.SetTop(enemyRectangle, enemyPoint.Y);

        }
    }
}
