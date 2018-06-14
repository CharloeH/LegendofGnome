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
           
            
            if (enemyPoint.X <= playerPoint.X || enemyPoint.X >= playerPoint.X || enemyPoint.Y <= playerPoint.Y || enemyPoint.Y >= playerPoint.Y)
            {
                if(enemyPoint.X <= playerPoint.X)
                {
                    enemyPoint.X += 5;
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
                if((enemyPoint.Y - playerPoint.Y == 20 || enemyPoint.Y - playerPoint.Y == -20) & (enemyPoint.X - playerPoint.Y == 20 || enemyPoint.X - playerPoint.X == -20))
                {
                    
                    attackCounter++;
                    if(attackCounter == 30)
                    {
                    MessageBox.Show("Tag! You're it!");
                     attackCounter = 0;
                    }
                }
                else
                {
                counter == 0;
                }
                
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
