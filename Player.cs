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

        public Point Move(Rectangle playerRectangle, Canvas canvas, Point playerPoint)
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                if (playerPoint.Y >= 55)
                {
                    
                    Console.WriteLine("w");
                    playerPoint.Y = playerPoint.Y - 10;

                }
                if(playerPoint.Y <= 55 & playerPoint.X >= 600 & playerPoint.X <= 650)
                    {
                    playerPoint.Y -= 10;
                    if (playerPoint.Y == -50)
                    {
                        playerPoint.Y = 1000;
                    }
                    }
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (playerPoint.Y <= 850)
                {
                    Console.WriteLine("s");
                    playerPoint.Y += 10;
                    
                }
                if(playerPoint.Y >= 850 & playerPoint.X >= 600 & playerPoint.X <= 650)
                {
                    playerPoint.Y += 10;
                    {
                        if(playerPoint.Y == 1050)
                        {
                            playerPoint.Y = 0;
                        }
                    }
                }
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                if (playerPoint.X >= 60)
                {
                    Console.WriteLine("a");
                    playerPoint.X -= 10;
                }
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                if (playerPoint.X <= 1170)
                {
                    Console.WriteLine("d");
                    playerPoint.X += 10;
                }
            }
            Update(playerRectangle, canvas, playerPoint);
            return playerPoint;
        }

        public void Update(Rectangle playerRectangle, Canvas canvas, Point playerPoint)
        {
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            Canvas.SetTop(playerRectangle, playerPoint.Y);
           
        }

        public void GeneratePlayer(Canvas canvas, Point playerPoint)
        {
            playerRectangle.Height = 50;
            playerRectangle.Width = 50;
            BitmapImage bitmapBackground = new BitmapImage(new Uri("Wizard Sprite.png", UriKind.Relative));
            ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            playerRectangle.Fill = backgroundBrush;
            canvas.Children.Add(playerRectangle);
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            Canvas.SetTop(playerRectangle, playerPoint.Y);
            
        }
    }

}
