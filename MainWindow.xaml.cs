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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Point playerPoint;
        public Point enemyPoint = new Point(800, 1000);
        Map map = new Map();
        Player player = new Player();
        List<Projectile> projectiles = new List<Projectile>();
        List<Enemy> enemies = new List<Enemy>();
        DispatcherTimer GameTimer = new DispatcherTimer();
        DispatcherTimer projectileTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            bool isGenerated = false;
            if (isGenerated == false)
            {
                map.backgroundGenerate(Canvas);
                enemies.Add(new Enemy(Canvas, enemyPoint));
                map.DoorGenerate(map.door1, Canvas);
                player.GeneratePlayer(Canvas, playerPoint);
                isGenerated = true;
            }

            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            GameTimer.Start();

            projectileTimer.Tick += MovementTimer_Tick;
            projectileTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            projectileTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < projectiles.Count(); i++)
            {
                try
                {
                    enemyPoint = enemies[i].Move(playerPoint, enemyPoint);
                    playerPoint = player.Move(player.playerRectangle, Canvas, playerPoint);
                    //Console.WriteLine(playerPoint.ToString());//troubleshooting
                }
                catch { }
            }
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < projectiles.Count(); i++)
            {
                projectiles[i].move();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show(e.GetPosition(Canvas).ToString());
            projectiles.Add(new Projectile(Canvas, this, playerPoint));
        }
    }
}
