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
using System.Windows.Threading;

namespace LegendofGnome
{
    class UserInterface
    {
        public StackPanel healthBar = new StackPanel();
        public Label moneyBag = new Label();
        public List<Rectangle> health = new List<Rectangle>();
        //Rectangle health = new Rectangle();
        
        public UserInterface(Canvas canvas, int maxHealth)
        {
            healthBar.Width = 900;
            healthBar.Height = 25;
            healthBar.Orientation = Orientation.Horizontal;
            canvas.Children.Add(healthBar);
            Canvas.SetTop(healthBar, 775);
            Canvas.SetLeft(healthBar, 200);
            for (int i = 0; i < maxHealth; i++)
            {
                health.Add(new Rectangle());
                health[i].Width = 10;
                health[i].Height = 25;
                health[i].Fill = Brushes.Red;
                health[i].Stroke = Brushes.White;
                healthBar.Children.Add(health[i]);
            }

            moneyBag.Foreground = Brushes.Goldenrod;
            moneyBag.Content = "Gold: ";
            canvas.Children.Add(moneyBag);
            Canvas.SetTop(moneyBag, 780);
            Canvas.SetLeft(moneyBag, 0);
        }

        public void updateHealth(int currentHealth, int maxHealth)
        {
            //otherwise we start increasing health, remove once we end the game
            if (currentHealth < 0) { currentHealth = 0; }
            //healthCounter allows us to store all of our boxes in one list, and keep track of them.
            int healthCounter = 0;
            //reset Healthbar and list everytime
            healthBar.Children.Clear();
            health.Clear();
            //adds remaining lives
            for (int i = 0; i < currentHealth; i++)
            {
                health.Add(new Rectangle());
                health[i].Width = 10;
                health[i].Height = 25;
                health[i].Fill = Brushes.Red;
                health[i].Stroke = Brushes.Black;
                healthBar.Children.Add(health[i]);
                healthCounter++;
            }
            //adds empty max lives
            for (int i = 0; i < maxHealth - currentHealth; i++)
            {
                health.Add(new Rectangle());
                health[i + healthCounter].Width = 10;
                health[i + healthCounter].Height = 25;
                health[i + healthCounter].Fill = Brushes.Transparent;
                health[i + healthCounter].Stroke = Brushes.Black;
                healthBar.Children.Add(health[i + healthCounter]);
            }
        }
    }
}
