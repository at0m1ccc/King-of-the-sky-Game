using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneGame
{
    public static class ObstaclesController
    {
        public static List<Obstacle> obstacles;
        public static bool checker = true;
        public static int score;
        public static int limScore = 60;

        public static void CreateObstacle()
        {
            for(var i = 0; i < 6; i++)
            {
                var currentObject = new Obstacle();
                ReCreateObstacle(currentObject, 0, 0, new Random());
                obstacles.Add(currentObject);
            }
        }

        public static void ReCreateObstacle(Obstacle obstacle, int width, int height, Random random)
        {
            Size newSize;
            Point currentPoint;
            string fileName = random.Next(1, 4).ToString();
            switch (fileName)
            {
                case "1":
                    width = 180;
                    height = 80;
                    break;
                case "2":
                    width = 225;
                    height = 85;
                    break;
                case "3":
                    width = 205;
                    height = 70;
                    break;
            }
            obstacle.imageObstacle = new Bitmap(@"C:\Users\Константин\OneDrive - УрФУ\Рабочий стол\AirplaneGame\AirplaneGame\bin\Debug\Obstacles\" + fileName + ".png");
            do
            {
                newSize = new Size(width, height);
                currentPoint = new Point(random.Next(Screen.PrimaryScreen.Bounds.Width - width, Screen.PrimaryScreen.Bounds.Width), random.Next(0, Screen.PrimaryScreen.Bounds.Width - width));
            }while(obstacles.Any(obs => currentPoint.X + newSize.Width >= obs.x && currentPoint.X <= obstacle.x + obs.size.Width));
            obstacle.size = newSize;
            obstacle.x = currentPoint.X;
            obstacle.y = currentPoint.Y;
        }

        public static void UpSpeed()
        {
            if(score == limScore)
            {
                for (var i = 0; i < obstacles.Count; i++)
                    obstacles[i].speed++;
                limScore += 60;
            };
        }

        public static void MoveObstacles(Player player)
        {
            foreach(var obstacle in obstacles)
            {
                obstacle.x -= obstacle.speed;
                if (obstacle.x + obstacle.size.Width < 0) 
                {
                    ReCreateObstacle(obstacle, 0, 0, new Random()); 
                }
            }
        }

        public static void CheckContact(Player player)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.CheckCrash(player))
                {
                    checker = false;
                }
            }
        }
    }
}
