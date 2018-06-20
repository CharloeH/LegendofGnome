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
        public bool isRoom1 = true;
        public bool isRoom2 = false;
        public bool isRoom3 = false;
        public bool isBossRoom = false;
        public bool isShopRoom = false;
        public Point playerPoint = new Point(500, 500);
        public Random mapRandom = new Random();
        public Rectangle door1 = new Rectangle();
        public Rectangle door2 = new Rectangle();
        public Rectangle door3 = new Rectangle();
        public Rectangle wallTop1 = new Rectangle();
        public Rectangle wallTop2 = new Rectangle();
        public Rectangle wallBot1 = new Rectangle();
        public Rectangle wallBot2 = new Rectangle();
        public Rectangle wallLeft1 = new Rectangle();
        public Rectangle wallLeft2 = new Rectangle();
        public Rectangle wallRight1 = new Rectangle();
        public Rectangle wallRight2 = new Rectangle();
        public Point enemyPoint = new Point(1000, 1000);
        Map map = new Map();
        Player player = new Player();
        UserInterface uI;
        Boss boss;
        bool respawn;
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
                map.MapGenerate(Canvas, door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                enemies.Add(new Enemy(Canvas, enemyPoint));
                player.GeneratePlayer(Canvas, playerPoint);
                uI = new UserInterface(Canvas, player.maxHealth);
                boss = new Boss(Canvas, this);
                uI.moneyBag.Content += player.gold.ToString();
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
            map.roomGenerate(isRoom1, isRoom2, isRoom3, isBossRoom, isShopRoom, door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);

            if (player.health <= 0)
            {
                MessageBox.Show("You Died");
                Environment.Exit(0);
            }

            for (int i = 0; i < enemies.Count(); i++)
            {
                enemyPoint = enemies[i].Move(playerPoint, enemyPoint, player.playerRectangle, respawn);

                Point tempT = new Point(Canvas.GetLeft(enemies[0].enemySword), Canvas.GetTop(enemies[0].enemySword));
                Point tempS = new Point(Canvas.GetLeft(player.playerSword), Canvas.GetTop(player.playerSword));
                if (enemies[0].isEnemy)
                {
                    if (enemies[i].attackAnimation != 0)
                    {
                        if (checkCollision(tempT, playerPoint, enemies[0].enemySword, player.playerRectangle))
                        {
                            player.health--;
                            uI.updateHealth(player.health, player.maxHealth);
                        }
                    }
                    if (player.attackAnimation != 0)
                    {
                        if (checkCollision(enemyPoint, tempS, enemies[0].enemyRectangle, player.playerSword))
                        {
                            //MessageBox.Show("hit");//troubleshooting
                            if (enemies[0].hit(true))
                            {
                                player.gold += 50;
                                uI.moneyBag.Content = "Gold: " + player.gold.ToString();
                            }
                        }
                    }
                }
            }
            if (isBossRoom)
            {
                if (boss.attack(playerPoint, player.playerRectangle))
                {
                    player.health = 0;
                    uI.updateHealth(player.health, player.maxHealth);
                }
            }

            playerPoint = player.Move(player.playerRectangle, Canvas, playerPoint, isRoom1, isRoom2, isRoom3, door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
            //Console.WriteLine(playerPoint.ToString());//troubleshooting
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            if (playerPoint.X >= 350 & playerPoint.X <= 450)
            {
                if (playerPoint.Y <= 60 & Keyboard.IsKeyDown(Key.W))
                {
                    playerPoint.Y -= 10;
                    if (playerPoint.Y <= 0)
                    {
                        if (isRoom1 == true)
                        {
                            playerPoint.Y = 750;
                            isRoom1 = false;
                            isRoom2 = true;
                            isRoom3 = false;

                            map.room2Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                            enemies[0].kill();
                            respawn = false;
                            return;
                        }
                        if (isRoom2 == true)
                        {
                            playerPoint.Y = 750;
                            isRoom1 = false;
                            isRoom2 = false;
                            isRoom3 = true;

                            map.room3Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                            enemies[0].kill();
                            respawn = true;
                            return;
                        }
                    }
                }
                if (playerPoint.Y >= 700 & Keyboard.IsKeyDown(Key.S))
                {
                    if (isRoom2 == true)
                    {
                        playerPoint.Y = 55;
                        isRoom1 = true;
                        isRoom2 = false;
                        isRoom3 = false;

                        map.room1Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                            wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                        enemies[0].kill();
                        respawn = true;
                        return;
                    }
                    if (isRoom3 == true)
                    {
                        playerPoint.Y = 55;
                        isRoom1 = false;
                        isRoom2 = true;
                        isRoom3 = false;
                        map.room2Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                        enemies[0].kill();
                        respawn = false;
                        return;
                    }
                }
            }
            if (playerPoint.Y >= 350 & playerPoint.Y <= 450)
            {
                if (playerPoint.X <= 60 & Keyboard.IsKeyDown(Key.A))
                {
                    playerPoint.X -= 10;
                    if (playerPoint.X <= 0)
                    {

                        if (isRoom3 == true)
                        {
                            playerPoint.X = 755;
                            isRoom1 = false;
                            isRoom2 = false;
                            isRoom3 = false;
                            isBossRoom = true;
                            isShopRoom = false;
                            map.bossRoomGenerate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                            boss.spawnBoss();
                            enemies[0].kill();
                            respawn = false;
                            return;
                        }
                        if (isShopRoom == true)
                        {
                            playerPoint.X = 755;
                            isRoom1 = false;
                            isRoom2 = false;
                            isRoom3 = true;
                            isBossRoom = false;
                            isShopRoom = false;
                            map.bossRoomGenerate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                            enemies[0].kill();
                            respawn = true;
                            return;
                        }
                    }
                }
                if (playerPoint.X >= 700 & Keyboard.IsKeyDown(Key.D))
                {
                    playerPoint.X += 10;
                    if (playerPoint.X >= 800)
                    {
                        if (isBossRoom == true)
                        {
                            playerPoint.X = 25;
                            isRoom1 = false;
                            isRoom2 = false;
                            isRoom3 = true;
                            isBossRoom = false;
                            isShopRoom = false;
                            map.room3Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                            enemies[0].kill();
                            respawn = true;
                            boss.youLeftTheRoom();
                            return;
                        }
                        if (isRoom3 == true)
                        {
                            playerPoint.X = 25;
                            isRoom1 = false;
                            isRoom2 = false;
                            isRoom3 = false;
                            isBossRoom = false;
                            isShopRoom = true;
                            map.shopRoomGeneate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                            enemies[0].kill();
                            respawn = false;
                            return;
                        }
                    }
                }
            }

            for (int i = 0; i < projectiles.Count(); i++)
            {
                if (projectiles[i].checkCollision(enemyPoint, enemies[0].enemyRectangle))
                {
                    if (enemies[0].hit(false))
                    {
                        Canvas.Children.Remove(projectiles[i].projectile);
                        player.gold += 50;
                        uI.moneyBag.Content = "Gold: " + player.gold.ToString();
                    }
                }
                if (projectiles[i].checkCollision(enemyPoint, enemies[0].enemyRectangle) || projectiles[i].move() == false)
                {
                    Canvas.Children.Remove(projectiles[i].projectile);
                    projectiles.Remove(projectiles[i]);
                }
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                projectiles.Add(new Projectile(Canvas, this, playerPoint));
            }
            //MessageBox.Show(e.GetPosition(Canvas).ToString());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.C))
            {
                isRoom1 = true;
                isRoom2 = false;
                isRoom3 = false;
                isBossRoom = false;
                isShopRoom = false;
            }
            if (Keyboard.IsKeyDown(Key.X))
            {
                isRoom1 = false;
                isRoom2 = true;
                isRoom3 = false;
                isBossRoom = false;
                isShopRoom = false;
            }
            if (Keyboard.IsKeyDown(Key.Z))
            {
                isRoom1 = false;
                isRoom2 = false;
                isRoom3 = true;
                isBossRoom = false;
                isShopRoom = false;
            }
            if (Keyboard.IsKeyDown(Key.V))
            {
                isRoom1 = false;
                isRoom2 = false;
                isRoom3 = false;
                isBossRoom = true;
                isShopRoom = false;
            }
            if (Keyboard.IsKeyDown(Key.B))
            {
                isRoom1 = false;
                isRoom2 = false;
                isRoom3 = false;
                isBossRoom = false;
                isShopRoom = true;
            }
        }

        public bool checkCollision(Point t, Point s, Rectangle target, Rectangle source)
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
    }
}
