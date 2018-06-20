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
        Random random = new Random();
        public bool isHit = false;
        public int attackCounter;
        public int attackAnimation = 0;
        public int respawnCounter;
        public int health;
        public int maxHealth = 10;
        public Point enemyPoint;
        public Rectangle enemyRectangle = new Rectangle();
        public Canvas canvas;
        public Rectangle enemySword = new Rectangle();
        public bool isEnemy;
        public bool hitThisAttack;

        public Enemy(Canvas c, Point eP)
        {
            canvas = c;
            enemyPoint = eP;
            Canvas.SetTop(enemyRectangle, enemyPoint.Y);
            Canvas.SetLeft(enemyRectangle, enemyPoint.X);
            Canvas.SetTop(enemySword, enemyPoint.Y + 10);
            Canvas.SetLeft(enemySword, enemyPoint.X - 5);
            enemyRectangle.Height = 50;
            enemyRectangle.Width = 50;
            enemySword.Height = 20;
            enemySword.Width = 20;
            enemySword.Fill = Brushes.DarkGray;
            enemyRectangle.Fill = Brushes.Red;
            canvas.Children.Add(enemyRectangle);
            canvas.Children.Add(enemySword);
            health = maxHealth;
            isEnemy = true;
        }

        public Point Move(Point playerPoint, Point eP, Rectangle playerRectangle, bool respawn)
        {
            enemyPoint = eP;
            if (isEnemy )
            {
                //attacks instead of moving
                if (attackAnimation != 0)
                {
                    attack();
                }
                //if not attacking moves him
                else
                {
                    if (checkAttack(enemyPoint, playerPoint, enemyRectangle, playerRectangle))
                    {
                        attackCounter++;
                        //Console.WriteLine(attackCounter);//troubleshooting
                        if (attackCounter == 15)
                        {
                            attackAnimation = 12;
                            attackCounter = 0;
                        }
                    }
                    //chases the player
                    if (enemyPoint.X <= playerPoint.X - 25)
                    {
                        enemyPoint.X += 5;
                    }
                    if (enemyPoint.X >= playerPoint.X + 25)
                    {
                        enemyPoint.X -= 5;
                    }
                    if (enemyPoint.Y >= playerPoint.Y + 25)
                    {
                        enemyPoint.Y -= 5;
                    }
                    if (enemyPoint.Y <= playerPoint.Y - 25)
                    {
                        enemyPoint.Y += 5;
                    }
                    Canvas.SetLeft(enemyRectangle, enemyPoint.X);
                    Canvas.SetTop(enemyRectangle, enemyPoint.Y);
                    Canvas.SetLeft(enemySword, enemyPoint.X + 10);
                    Canvas.SetTop(enemySword, enemyPoint.Y - 5);
                }
            }

            //You have the right to an Enemy. If you cannot afford an Enemy, one will be provided for you.
            else if (respawn == true)
            {
                respawnCounter++;
                //Console.WriteLine(attackCounter);//troubleshooting
                if (respawnCounter == 300)
                {
                    //MessageBox.Show("i never die");//troubleshooting
                    respawnCounter = 0;
                    canvas.Children.Add(enemyRectangle);
                    canvas.Children.Add(enemySword);
                    isEnemy = true;
                    health = maxHealth;
                    Canvas.SetTop(enemyRectangle, enemyPoint.Y);
                    Canvas.SetLeft(enemyRectangle, enemyPoint.X);
                    Canvas.SetTop(enemySword, enemyPoint.Y + 10);
                    Canvas.SetLeft(enemySword, enemyPoint.X - 5);
                }
            }
            return enemyPoint;
        }

        public bool checkAttack(Point t, Point s, Rectangle target, Rectangle source)
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

        public void attack()
        {
            if (attackAnimation == 10 || attackAnimation == 11 || attackAnimation == 12)
            {
                Canvas.SetLeft(enemySword, enemyPoint.X + 15);
                Canvas.SetTop(enemySword, enemyPoint.Y - 20);
            }
            if (attackAnimation == 7 || attackAnimation == 8 || attackAnimation == 9)
            {
                Canvas.SetLeft(enemySword, enemyPoint.X - 20);
                Canvas.SetTop(enemySword, enemyPoint.Y + 15);
            }
            if (attackAnimation == 4 || attackAnimation == 5 || attackAnimation ==6)
            {
                Canvas.SetLeft(enemySword, enemyPoint.X + 15);
                Canvas.SetTop(enemySword, enemyPoint.Y + 50);
            }
            if (attackAnimation == 1 || attackAnimation == 2 || attackAnimation == 3)
            {
                Canvas.SetLeft(enemySword, enemyPoint.X + 50);
                Canvas.SetTop(enemySword, enemyPoint.Y + 15);
            }
            attackAnimation--;
        }

        public bool hit(bool melee)
        {
            bool temp = false;
            if (health == 0 || melee)
            {
                kill();
                temp = true;
            }
            else
            {
                health--;
            }
            //Console.WriteLine("enemy health: " + health);//troubleshooting
            return temp;
        }

        public void kill()
        {
            enemyPoint.X = random.Next(50, 799);
            enemyPoint.Y = random.Next(50, 799);
            canvas.Children.Remove(this.enemySword);
            canvas.Children.Remove(this.enemyRectangle);
            isEnemy = false;
        }
    }
}
