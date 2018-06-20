using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Map
    {

        
        public Point wallPoint = new Point(0, 0);

        public Point doorPoint = new Point(0, 0);

        public void MapGenerate(Canvas canvas, Rectangle wallTop1, Rectangle wallTop2, Rectangle wallRight1, 
            Rectangle wallRight2, Rectangle wallLeft1, Rectangle wallLeft2, Rectangle wallBot1, 
            Rectangle wallBot2, Rectangle door1, Rectangle door2, Rectangle door3 )
        {

            canvas.Children.Add(wallLeft1);
            canvas.Children.Add(wallTop1);

            canvas.Children.Add(wallLeft2);
            canvas.Children.Add(wallBot1);

            canvas.Children.Add(wallRight1);
            canvas.Children.Add(wallTop2);

            canvas.Children.Add(wallRight2);
            canvas.Children.Add(wallBot2);

            canvas.Children.Add(door3);
            canvas.Children.Add(door1);
            canvas.Children.Add(door2);



            


            


           

        }
        public void room1Generate(Rectangle door1, Rectangle door2, Rectangle door3, 
            Rectangle wallTop1, Rectangle wallTop2, Rectangle wallLeft1, Rectangle wallLeft2, 
            Rectangle wallRight1, Rectangle wallRight2, Rectangle wallBot1, Rectangle wallBot2)
        {
            wallLeft1.Fill = Brushes.Black;
            wallLeft1.Height = 350;
            wallLeft1.Width = 50;
            Canvas.SetLeft(wallLeft1, wallPoint.X);
            Canvas.SetTop(wallLeft1, wallPoint.Y + 50);

            wallTop1.Fill = Brushes.Black;
            wallTop1.Height = 50;
            wallTop1.Width = 350;


            wallLeft2.Fill = Brushes.Black;
            wallLeft2.Height = 350;
            wallLeft2.Width = 50;
            Canvas.SetTop(wallLeft2, wallPoint.Y + 400);

            wallBot1.Fill = Brushes.Black;
            wallBot1.Height = 50;
            wallBot1.Width = 400;
            Canvas.SetTop(wallBot1, wallPoint.Y + 750);


            wallRight1.Fill = Brushes.Black;
            wallRight1.Height = 350;
            wallRight1.Width = 50;
            Canvas.SetLeft(wallRight1, wallPoint.X + 750);
            Canvas.SetTop(wallRight1, wallPoint.Y + 50);

            wallTop2.Fill = Brushes.Black;
            wallTop2.Height = 50;
            wallTop2.Width = 350;
            Canvas.SetLeft(wallTop2, wallPoint.X + 450);


            wallRight2.Fill = Brushes.Black;
            wallRight2.Height = 350;
            wallRight2.Width = 50;
            Canvas.SetTop(wallRight2, wallPoint.Y + 400);
            Canvas.SetLeft(wallRight2, wallPoint.X + 750);

            wallBot2.Fill = Brushes.Black;
            wallBot2.Height = 50;
            wallBot2.Width = 400;
            Canvas.SetLeft(wallBot2, wallPoint.X + 400);
            Canvas.SetTop(wallBot2, wallPoint.Y + 750);


            door1.Fill = Brushes.Red;
            door1.Height = 25;
            door1.Width = 100;
            Canvas.SetLeft(door1, doorPoint.X + 350);
            Canvas.SetTop(door1, doorPoint.Y);

            door2.Fill = Brushes.Transparent;
            door2.Height = 25;
            door2.Width = 100;
            Canvas.SetLeft(door2, doorPoint.X + 350);
            Canvas.SetTop(door2, doorPoint.Y + 775);

            door3.Fill = Brushes.Transparent;
        }
        public void room2Generate(Rectangle door1, Rectangle door2, Rectangle door3, 
            Rectangle wallTop1, Rectangle wallTop2, Rectangle wallLeft1, Rectangle wallLeft2, 
            Rectangle wallRight1, Rectangle wallRight2, Rectangle wallBot1, Rectangle wallBot2)
        {
            wallLeft1.Width = 300;
            wallLeft1.Height = 400;
            wallLeft1.Fill = Brushes.Black;
            Canvas.SetLeft(wallLeft1, wallPoint.X);

            wallTop1.Fill = Brushes.Black;
            wallTop1.Width = 350;

            wallLeft2.Fill = Brushes.Black;
            wallLeft2.Width = 300;
            wallLeft2.Height = 400;
            Canvas.SetTop(wallLeft2, wallPoint.Y + 400);
            

            wallBot1.Fill = Brushes.Black;
            wallBot1.Width = 350;
            Canvas.SetTop(wallBot1, wallPoint.Y + 750);

            wallRight1.Width = 300;
            wallRight1.Height = 350;
            Canvas.SetLeft(wallRight1, wallPoint.X + 500);
            Canvas.SetTop(wallRight1, wallPoint.Y + 50);
            wallRight1.Fill = Brushes.Black;
            
            wallTop2.Fill = Brushes.Black;
            wallTop2.Width = 350;
            Canvas.SetLeft(wallTop2, wallPoint.X + 450);


            wallRight2.Width = 300;
            wallRight2.Height = 350;
            wallRight2.Fill = Brushes.Black;
            Canvas.SetLeft(wallRight2, wallPoint.X + 500);
            Canvas.SetTop(wallRight2, wallPoint.Y + 400);
            

            wallBot2.Height = 50;
            wallBot2.Width = 350;
            wallBot2.Fill = Brushes.Black;
            Canvas.SetLeft(wallBot2, wallPoint.X + 450);
            Canvas.SetTop(wallBot2, wallPoint.Y + 750);


            door1.Height = 25;
            door1.Width = 100;
            door1.Fill = Brushes.Blue;
            Canvas.SetLeft(door1, doorPoint.X + 350);
            Canvas.SetTop(door1, doorPoint.Y);

            door2.Height = 25;
            door2.Width = 100;
            door2.Fill = Brushes.Blue;
            Canvas.SetLeft(door2, doorPoint.X + 350);
            Canvas.SetTop(door2, doorPoint.Y + 775);

            door3.Fill = Brushes.Transparent;
        }
        public void room3Generate(Rectangle door1, Rectangle door2, Rectangle door3, 
            Rectangle wallTop1, Rectangle wallTop2, Rectangle wallLeft1, Rectangle wallLeft2,
            Rectangle wallRight1, Rectangle wallRight2, Rectangle wallBot1, Rectangle wallBot2)
        {
           

           
            wallLeft1.Fill = Brushes.Black;
            wallLeft1.Height = 350;
            wallLeft1.Width = 50;
            Canvas.SetLeft(wallLeft1, wallPoint.X);
            Canvas.SetTop(wallLeft1, wallPoint.Y);

            wallTop1.Fill = Brushes.Black;
            wallTop1.Height = 50;
            wallTop1.Width = 400;
            Canvas.SetLeft(wallTop1, wallPoint.X);
            Canvas.SetTop(wallTop1, wallPoint.Y);

            wallLeft2.Fill = Brushes.Black;
            wallLeft2.Height = 350;
            wallLeft2.Width = 50;
            Canvas.SetLeft(wallLeft2, wallPoint.X);
            Canvas.SetTop(wallLeft2, wallPoint.Y + 450);

            wallBot1.Fill = Brushes.Black;
            wallBot1.Height = 50;
            wallBot1.Width = 350;
            Canvas.SetLeft(wallBot1, wallPoint.X);
            Canvas.SetTop(wallBot1, wallPoint.Y + 750);


            wallRight1.Fill = Brushes.Black;
            wallRight1.Height = 300;
            wallRight1.Width = 50;
            Canvas.SetLeft(wallRight1, wallPoint.X + 750);
            Canvas.SetTop(wallRight1, wallPoint.Y + 50);

            wallTop2.Fill = Brushes.Black;
            wallTop2.Height = 50;
            wallTop2.Width = 400;
            Canvas.SetLeft(wallTop2, wallPoint.X + 400);
            Canvas.SetTop(wallTop2, wallPoint.Y);


            wallRight2.Fill = Brushes.Black;
            wallRight2.Height = 300;
            wallRight2.Width = 50;
            Canvas.SetTop(wallRight2, wallPoint.Y + 450);
            Canvas.SetLeft(wallRight2, wallPoint.X + 750);
           
            wallBot2.Fill = Brushes.Black;
            wallBot2.Height = 50;
            wallBot2.Width = 350;
            Canvas.SetLeft(wallBot2, wallPoint.X + 450);
            Canvas.SetTop(wallBot2, wallPoint.Y + 750);

            door1.Fill = Brushes.Green;
            door1.Height = 25;
            door1.Width = 100;
            Canvas.SetLeft(door1, doorPoint.X + 350);
            Canvas.SetTop(door1, doorPoint.Y + 775);

            door2.Fill = Brushes.Green;
            door2.Height = 100;
            door2.Width = 25;
            Canvas.SetLeft(door2, doorPoint.X);
            Canvas.SetTop(door2, doorPoint.Y + 350);

            door3.Fill = Brushes.Green;
            door3.Height = 100;
            door3.Width = 25;
            Canvas.SetLeft(door3, doorPoint.X + 775);
            Canvas.SetTop(door3, doorPoint.Y + 350);
        }
        public void bossRoomGenerate(Rectangle door1, Rectangle door2, Rectangle door3, 
            Rectangle wallTop1, Rectangle wallTop2, Rectangle wallLeft1, Rectangle wallLeft2, 
            Rectangle wallRight1, Rectangle wallRight2, Rectangle wallBot1, Rectangle wallBot2)
        {
            wallLeft1.Height = 350;
            wallLeft1.Width = 50;
            wallLeft1.Fill = Brushes.DarkRed;
            Canvas.SetLeft(wallLeft1, wallPoint.X);
            Canvas.SetTop(wallLeft1, wallPoint.Y + 50);

            wallTop1.Height = 50;
            wallTop1.Width = 400;
            wallTop1.Fill = Brushes.DarkRed;
            Canvas.SetLeft(wallTop1, wallPoint.X);
            Canvas.SetTop(wallTop1, wallPoint.Y);

            wallLeft2.Height = 350;
            wallLeft2.Width = 50;
            wallLeft2.Fill = Brushes.DarkRed;
            Canvas.SetLeft(wallLeft2, wallPoint.X);
            Canvas.SetTop(wallLeft2, wallPoint.Y + 400);

            wallBot1.Height = 50;
            wallBot1.Width = 400;
            wallBot1.Fill = Brushes.DarkRed;
            Canvas.SetLeft(wallBot1, wallPoint.X);
            Canvas.SetTop(wallBot1, wallPoint.Y + 750);

            wallRight1.Height = 300;
            wallRight1.Width = 50;
            wallRight1.Fill = Brushes.DarkRed;
            Canvas.SetLeft(wallRight1, wallPoint.X + 750);
            Canvas.SetTop(wallRight1, wallPoint.Y + 50);

            wallTop2.Height = 50;
            wallTop2.Width = 400;
            wallTop2.Fill = Brushes.DarkRed;
            Canvas.SetLeft(wallTop2, wallPoint.X + 400);
            Canvas.SetTop(wallTop2, wallPoint.Y);

            wallRight2.Height = 300;
            wallRight2.Width = 50;
            wallRight2.Fill = Brushes.DarkRed;
            Canvas.SetLeft(wallRight2, wallPoint.X + 750);
            Canvas.SetTop(wallRight2, wallPoint.Y + 450);

            wallBot2.Height = 50;
            wallBot2.Width = 400;
            wallBot2.Fill = Brushes.DarkRed;
            Canvas.SetLeft(wallBot2, wallPoint.X + 400);
            Canvas.SetTop(wallBot2, wallPoint.Y + 750);


            door1.Height = 100;
            door1.Width = 25;
            door1.Fill = Brushes.Yellow;
            Canvas.SetLeft(door1, wallPoint.X + 775);
            Canvas.SetTop(door1, wallPoint.Y + 350);

            door2.Fill = Brushes.Transparent;
            door3.Fill = Brushes.Transparent;
        }
        public void shopRoomGeneate(Rectangle door1, Rectangle door2, Rectangle door3,
            Rectangle wallTop1, Rectangle wallTop2, Rectangle wallLeft1, Rectangle wallLeft2,
            Rectangle wallRight1, Rectangle wallRight2, Rectangle wallBot1, Rectangle wallBot2)
        {
            wallLeft1.Height = 350;
            wallLeft1.Width = 50;
            wallLeft1.Fill = Brushes.DarkBlue;
            Canvas.SetLeft(wallLeft1, wallPoint.X);
            Canvas.SetTop(wallLeft1, wallPoint.Y);

            wallTop1.Height = 50;
            wallTop1.Width = 400;
            wallTop1.Fill = Brushes.DarkBlue;
            Canvas.SetLeft(wallTop1, wallPoint.X);
            Canvas.SetTop(wallTop1, wallPoint.Y);

            wallLeft2.Height = 350;
            wallLeft2.Width = 50;
            wallLeft2.Fill = Brushes.DarkBlue;
            Canvas.SetLeft(wallLeft2, wallPoint.X);
            Canvas.SetTop(wallLeft2, wallPoint.Y + 450);

            wallBot1.Height = 50;
            wallBot1.Width = 400;
            wallBot1.Fill = Brushes.DarkBlue;
            Canvas.SetLeft(wallBot1, wallPoint.X);
            Canvas.SetTop(wallBot1, wallPoint.Y + 750);

            wallRight1.Height = 350;
            wallRight1.Width = 50;
            wallRight1.Fill = Brushes.DarkBlue;
            Canvas.SetLeft(wallRight1, wallPoint.X + 750);
            Canvas.SetTop(wallRight1, wallPoint.Y + 50);

            wallTop2.Height = 50;
            wallTop2.Width = 400;
            wallTop2.Fill = Brushes.DarkBlue;
            Canvas.SetLeft(wallTop2, wallPoint.X + 400);
            Canvas.SetTop(wallTop2, wallPoint.Y);

            wallRight2.Height = 350;
            wallRight2.Width = 50;
            wallRight2.Fill = Brushes.DarkBlue;
            Canvas.SetLeft(wallRight2, wallPoint.X + 750);
            Canvas.SetTop(wallRight2, wallPoint.Y + 400);

            wallBot2.Height = 50;
            wallBot2.Width = 400;
            wallBot2.Fill = Brushes.DarkBlue;
            Canvas.SetLeft(wallBot2, wallPoint.X + 400);
            Canvas.SetTop(wallBot2, wallPoint.Y + 750);


            door1.Height = 100;
            door1.Width = 25;
            door1.Fill = Brushes.Yellow;
            Canvas.SetLeft(door1, wallPoint.X);
            Canvas.SetTop(door1, wallPoint.Y + 350);

            door2.Fill = Brushes.Transparent;
            door3.Fill = Brushes.Transparent;
        }
        public void roomGenerate(bool isRoom1, bool isRoom2, bool isRoom3, bool isBossRoom, bool isShopRoom, Rectangle door1, Rectangle door2, Rectangle door3,
            Rectangle wallTop1, Rectangle wallTop2, Rectangle wallLeft1, Rectangle wallLeft2,
            Rectangle wallRight1, Rectangle wallRight2, Rectangle wallBot1, Rectangle wallBot2)
        {
        
            if (isRoom1 == true)
            {
                
                room1Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
            }
            if (isRoom2 == true)
            {
               
                room2Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);

            }
            if (isRoom3 == true)
            {
                room3Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
            }
            if(isBossRoom == true)
            {
                bossRoomGenerate(door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
            }
            if(isShopRoom == true)
            {
                shopRoomGeneate(door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
            }
        }
    }
}
