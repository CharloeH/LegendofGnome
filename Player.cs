using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Player
    {
        
      

        public Rectangle player_rectangle = new Rectangle();

        public Point Move(Rectangle player_rectangle, Canvas canvas, Point playerPoint)
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                if (playerPoint.Y >= 0)
                {
                    Console.WriteLine("w");
                    playerPoint.Y = playerPoint.Y - 1;

                   
                    

                }
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (playerPoint.Y <= 910)
                {
                    Console.WriteLine("s");
                    playerPoint.Y += 1;
                    
                }
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                if (playerPoint.X >= 0)
                {
                    Console.WriteLine("a");
                    playerPoint.X -= 1;
                }
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                if (playerPoint.X <= 1230)
                {
                    Console.WriteLine("d");
                    playerPoint.X += 1;
                }
            }
            Update(player_rectangle, canvas, playerPoint);
            return playerPoint;
        }

        public void Update(Rectangle player_rectangle, Canvas canvas, Point playerPoint)
        {
            Canvas.SetLeft(player_rectangle, playerPoint.X);
            Canvas.SetTop(player_rectangle, playerPoint.Y);
           
        }

        public void GeneratePlayer(Canvas canvas, Point playerPoint)
        {
            player_rectangle.Height = 50;
            player_rectangle.Width = 50;
            canvas.Children.Add(player_rectangle);
            Canvas.SetLeft(player_rectangle, playerPoint.X);
            Canvas.SetTop(player_rectangle, playerPoint.Y);
            player_rectangle.Fill = Brushes.Red;
        }
    }

}
