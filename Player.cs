using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Player
    {
        public Rectangle playerRectangle = new Rectangle();
        public Rectangle playerSword = new Rectangle();
        Map map = new Map();
        public int attackAnimation = 0;
        public Point playerPoint;
        public int maxHealth = 10;
        public int health;
        public int gold = 0;

        public Point Move(Rectangle playerRectangle, Canvas canvas, Point pP, bool isRoom1, bool isRoom2, bool isRoom3, Rectangle door1, Rectangle door2, Rectangle door3, Rectangle wallTop1, Rectangle wallTop2, Rectangle wallLeft1, Rectangle wallLeft2, Rectangle wallRight1, Rectangle wallRight2, Rectangle wallBot1, Rectangle wallBot2)
        {
            playerPoint = pP;
            if (Keyboard.IsKeyDown(Key.W))
            {
                if (playerPoint.Y >= 50)
                {
                    //Console.WriteLine("w");
                    playerPoint.Y = playerPoint.Y - 10;
                }
                if (isRoom1 == true)
                {
                    if (playerPoint.Y <= 55 & playerPoint.X >= 450 & playerPoint.X <= 550)
                    {
                        //MessageBox.Show("wrong!");
                        playerPoint.Y -= 10;
                        if (playerPoint.Y == -50)
                        {
                            playerPoint.Y = 1000;
                        }
                    }
                }
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (playerPoint.Y <= 700)
                {
                    //Console.WriteLine("s");
                    playerPoint.Y += 10;
                }

            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                if (isRoom2 == true)
                {
                    if (playerPoint.X >= 300 & playerPoint.X <= 500)
                    {
                        playerPoint.X -= 10;
                    }
                }
                else
                {
                    if (playerPoint.X >= 50)
                    {

                        //Console.WriteLine("a");
                        playerPoint.X -= 10;
                    }
                }
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                if (isRoom2 == true)
                {
                    if (playerPoint.X >= 300 & playerPoint.X <= 450)
                    {
                        playerPoint.X += 10;
                    }
                }
                else
                {
                    if (playerPoint.X <= 725)
                    {
                        //Console.WriteLine("d");
                        playerPoint.X += 10;
                    }
                }
            }
            //if right click
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                //and you are attacking, continue
                if (attackAnimation != 0)
                {
                    attack();
                }
                //otherwise, start.
                else if (attackAnimation == 0)
                {
                    attackAnimation = 12;
                }
            }
            //returns sword to resting position when not being swung
            else if (Mouse.RightButton != MouseButtonState.Pressed)
            {
                Canvas.SetLeft(playerSword, playerPoint.X + 10);
                Canvas.SetTop(playerSword, playerPoint.Y - 5);
            }
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            Canvas.SetTop(playerRectangle, playerPoint.Y);
            return playerPoint;
        }

        public void GeneratePlayer(Canvas canvas, Point pP)
        {
            playerPoint = pP;
            playerRectangle.Height = 50;
            playerRectangle.Width = 50;
            BitmapImage bitmapBackground = new BitmapImage(new Uri("Wizard Sprite.png", UriKind.Relative));
            ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            playerRectangle.Fill = backgroundBrush;
            canvas.Children.Add(playerRectangle);
            canvas.Children.Add(playerSword);
            playerSword.Height = 20;
            playerSword.Width = 20;
            playerSword.Fill = Brushes.DarkGray;
            Canvas.SetLeft(playerSword, playerPoint.X + 10);
            Canvas.SetTop(playerSword, playerPoint.Y - 5);
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            Canvas.SetTop(playerRectangle, playerPoint.Y);
            health = maxHealth;
        }

        public void attack()
        {
            if (attackAnimation == 10 || attackAnimation == 11 || attackAnimation == 12)
            {
                Canvas.SetLeft(playerSword, playerPoint.X + 15);
                Canvas.SetTop(playerSword, playerPoint.Y - 20);
            }
            if (attackAnimation == 7 || attackAnimation == 8 || attackAnimation == 9)
            {
                Canvas.SetLeft(playerSword, playerPoint.X - 20);
                Canvas.SetTop(playerSword, playerPoint.Y + 15);
            }
            if (attackAnimation == 4 || attackAnimation == 5 || attackAnimation == 6)
            {
                Canvas.SetLeft(playerSword, playerPoint.X + 15);
                Canvas.SetTop(playerSword, playerPoint.Y + 50);
            }
            if (attackAnimation == 1 || attackAnimation == 2 || attackAnimation == 3)
            {
                Canvas.SetLeft(playerSword, playerPoint.X + 50);
                Canvas.SetTop(playerSword, playerPoint.Y + 15);
            }
            attackAnimation--;
        }
    }
}
