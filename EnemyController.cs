using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AirplaneGame
{
    public static class EnemyController
    {
        public static List<Enemy> obstacles;
        public static bool checkerWithPlayer = true;
        public static int score;
        public static int bestScore;
        public static int limScore;

        public static void CreateObstacle()
        {
            for(var i = 0; i < DifficultyLevel.maxCountWarior; i++)
            {
                var currentObject = new Enemy();
                ReCreateObstacle(currentObject, 0, 0, new Random());
                obstacles.Add(currentObject);
            }
        }

        public static void ReCreateObstacle(Enemy obstacle, int width, int height, Random random)
        {
            Size newSize;
            Point currentPoint;
            obstacle.fileName = random.Next(1, 4).ToString();
            switch (obstacle.fileName)
            {
                case "1":
                    width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.129);
                    height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.109);
                    break;
                case "2":
                    width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.139);
                    height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.109);
                    break;
                case "3":
                    width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.143);
                    height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.080);
                    break;
            }
            obstacle.imageObstacle = Directory.sprites[$"{obstacle.fileName}" + ".png"];
            do
            {
                newSize = new Size(width, height);
                currentPoint = new Point(Screen.PrimaryScreen.Bounds.Width + random.Next(100, 300), random.Next(0, Screen.PrimaryScreen.Bounds.Height-newSize.Height));
            } while (obstacles.Any(obs => currentPoint.Y + newSize.Height >= obs.y && currentPoint.Y <= obs.y + obs.size.Height));
            obstacle.size = newSize;
            obstacle.x = currentPoint.X;
            obstacle.y = currentPoint.Y;
            CreateRegion(obstacle);
        }

        private static void CreateRegion(Enemy obstacle)
        {
            obstacle.grPath = new GraphicsPath();
            switch(obstacle.fileName)
            {
                case "1":
                    obstacle.grPath.AddPolygon(new Point[] {new Point(obstacle.x, obstacle.y+obstacle.size.Height/5),
                        new Point(obstacle.x+obstacle.size.Width/8, obstacle.y+obstacle.size.Height/4),
                        new Point(obstacle.x+obstacle.size.Width/4, obstacle.y+obstacle.size.Height/20),
                        new Point(obstacle.x+obstacle.size.Width/2, obstacle.y+obstacle.size.Height/15),
                        new Point(obstacle.x+obstacle.size.Width/2, obstacle.y+obstacle.size.Height/3),
                        new Point(obstacle.x+obstacle.size.Width*8/10, obstacle.y+obstacle.size.Height/3),
                        new Point(obstacle.x+obstacle.size.Width*92/100, obstacle.y+obstacle.size.Height/10),
                        new Point(obstacle.x+obstacle.size.Width*2/5, obstacle.y+obstacle.size.Height),
                        new Point(obstacle.x+obstacle.size.Width/2, obstacle.y+obstacle.size.Height*7/10),
                        new Point(obstacle.x+obstacle.size.Width*3/10, obstacle.y+obstacle.size.Height*3/4),
                        new Point(obstacle.x+obstacle.size.Width*2/10, obstacle.y+obstacle.size.Height*19/20),
                        new Point(obstacle.x+obstacle.size.Width*1/10, obstacle.y+obstacle.size.Height*6/10),
                        new Point(obstacle.x, obstacle.y+obstacle.size.Height*8/10)});
                    obstacle.hitbox = new Region(obstacle.grPath);
                    break;
                case "2":
                    obstacle.grPath.AddPolygon(new Point[] { new Point(obstacle.x, obstacle.y+obstacle.size.Height*59/100),
                        new Point(obstacle.x + obstacle.size.Width * 196 / 1000, obstacle.y+obstacle.size.Height*31/100),
                        new Point(obstacle.x+obstacle.size.Width*32/100, obstacle.y+obstacle.size.Height*38/100),
                        new Point(obstacle.x+obstacle.size.Width * 76 / 100, obstacle.y+obstacle.size.Height*46/100),
                        new Point(obstacle.x+obstacle.size.Width*87/100, obstacle.y),
                        new Point(obstacle.x+obstacle.size.Width*95/100, obstacle.y+obstacle.size.Height * 2 / 100),
                        new Point(obstacle.x+obstacle.size.Width, obstacle.y+obstacle.size.Height*58/100),
                        new Point(obstacle.x+obstacle.size.Width*88/100, obstacle.y+obstacle.size.Height*85/100),
                        new Point(obstacle.x+obstacle.size.Width*71/100, obstacle.y+obstacle.size.Height),
                        new Point(obstacle.x+obstacle.size.Width*38/100, obstacle.y+obstacle.size.Height*71/100),
                        new Point(obstacle.x+obstacle.size.Width*19/100, obstacle.y+obstacle.size.Height*95/100),
                        new Point(obstacle.x+obstacle.size.Width*17/100, obstacle.y+obstacle.size.Height*7/10)});
                    obstacle.hitbox = new Region(obstacle.grPath);
                    break;
                case "3":
                    obstacle.grPath.AddPolygon(new Point[] {new Point(obstacle.x, obstacle.y+obstacle.size.Height*6/10),
                        new Point(obstacle.x+obstacle.size.Width/2, obstacle.y+obstacle.size.Height),
                        new Point(obstacle.x+obstacle.size.Width*4/10, obstacle.y+obstacle.size.Height/4),
                        new Point(obstacle.x+obstacle.size.Width, obstacle.y+obstacle.size.Height*6/10),
                        new Point(obstacle.x+obstacle.size.Width/2, obstacle.y),
                        new Point(obstacle.x+obstacle.size.Width*6/10, obstacle.y+obstacle.size.Height*2/10),
                        new Point(obstacle.x+obstacle.size.Width*12/100, obstacle.y+obstacle.size.Height* 42 /100),
                        new Point(obstacle.x+obstacle.size.Width * 86 / 100, obstacle.y+obstacle.size.Height*42/100)});
                    obstacle.hitbox = new Region(obstacle.grPath);
                    break;
            }
        }

        public static void UpSpeed()
        {
            if(score == limScore)
            {
                for (var i = 0; i < obstacles.Count; i++)
                    obstacles[i].speed += 1;
                limScore += 20;
            };
        }

        public static void MoveObstacles()
        {
            foreach(var obstacle in obstacles)
            {
                obstacle.x -= obstacle.speed;
                CreateRegion(obstacle);
                if (obstacle.x + obstacle.size.Width < 0) 
                {
                    ReCreateObstacle(obstacle, 0, 0, new Random()); 
                }
            }
        }

        public static void CheckContactWithPlayer(Player player)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.CheckCrash(player))
                {
                    checkerWithPlayer = false;
                }
            }
        }

        public static void CheckContactWithStandartBullets(StandartBullet bullet)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.HitWIthStandartBullet(bullet))
                {
                    score += 5;
                    ReCreateObstacle(obstacle, 0, 0, new Random());
                    StandartBulletController.StandartBullets.Remove(bullet);
                }
            }
        }

        public static void CheckContactWithSplittingBullets(SplittingBullet bullet)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.HitWIthSplittingBullet(bullet))
                {
                    score += 5;
                    EnemyController.ReCreateObstacle(obstacle, 0, 0, new Random());
                    if (bullet.split == 0)
                    {
                        bullet.split++;
                        SplittingBulletController.MakeMiniBulletGoDown(bullet);
                        SplittingBulletController.MakeMiniBulletGoUp(bullet);
                        SplittingBulletController.splittingBullets.Remove(bullet);
                    }
                    else if (bullet.split == 1)
                        SplittingBulletController.miniSplittingBulletsUp.Remove(bullet);
                    else
                        SplittingBulletController.miniSplittingBulletsDown.Remove(bullet);
                }
            }
        }
    }
}
