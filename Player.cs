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
        Map map = new Map();
        public Point Move(Rectangle playerRectangle, Canvas canvas, Point playerPoint, bool isRoom1, bool isRoom2, bool isRoom3, Rectangle door1, Rectangle door2, Rectangle door3, Rectangle wallTop1, Rectangle wallTop2, Rectangle wallLeft1, Rectangle wallLeft2, Rectangle wallRight1, Rectangle wallRight2, Rectangle wallBot1, Rectangle wallBot2)
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                if (playerPoint.Y >= 50)
                {

                    Console.WriteLine("w");
                    playerPoint.Y = playerPoint.Y - 10;

                }
               
                
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (playerPoint.Y <= 700)
                {
                   
                    playerPoint.Y += 10;

                }
                
                
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                if (playerPoint.X >= 50)
                {
                    Console.WriteLine("a");
                    playerPoint.X -= 10;
                }
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                if (playerPoint.X <= 700)
                {
                    
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
