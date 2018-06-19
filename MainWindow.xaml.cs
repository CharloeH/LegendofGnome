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
        public bool isRoom1 = false;
        public bool isRoom2 = false;
        public bool isRoom3 = false;
        public Point playerPoint = new Point(500, 500);
        public enum RoomNumber { room1, room2, room3, none }
        public Point enemyPoint = new Point(800, 1000);
        Map map = new Map();
        Player player = new Player();
        List<Projectile> projectiles = new List<Projectile>();
        List<Enemy> enemies = new List<Enemy>();
        DispatcherTimer GameTimer = new DispatcherTimer();
        DispatcherTimer projectileTimer = new DispatcherTimer();
        public RoomNumber roomNumber;
        public MainWindow()
        {
            InitializeComponent();
            map.roomNumber = RoomNumber.none;
            bool isGenerated = false;
            if (isGenerated == false)
            {
                map.MapGenerate(map.door1,Canvas, isRoom1);
                enemies.Add(new Enemy(Canvas, enemyPoint));
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
            map.roomGenerate(isRoom1, isRoom2, isRoom3);
            for (int i = 0; i < projectiles.Count(); i++)
            {
                try
                {
                    //enemyPoint = enemies[i].Move(playerPoint, enemyPoint);
                    playerPoint = player.Move(player.playerRectangle, Canvas, playerPoint, isRoom1, isRoom2, isRoom3);
                    Console.WriteLine(playerPoint.ToString());//troubleshooting
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.C))
            {
                isRoom1 = true;
                isRoom2 = false;
                isRoom3 = false;
                //MessageBox.Show(map.roomNumber.ToString());
            }
            if (Keyboard.IsKeyDown(Key.X))
            {
                isRoom1 = false;
                isRoom2 = true;
                isRoom3 = false;
               // MessageBox.Show(map.roomNumber.ToString());
            }
            if (Keyboard.IsKeyDown(Key.Z))
            {
                isRoom1 = false;
                isRoom2 = false;
                isRoom3 = true;
               // MessageBox.Show(map.roomNumber.ToString());
            }
        }
    }
}
