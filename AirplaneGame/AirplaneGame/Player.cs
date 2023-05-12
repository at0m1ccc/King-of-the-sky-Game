using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneGame
{
    public class Player
    {
        public Image playerImage;
        public int x;
        public int y;
        public Size size;
        public int currentShot;
        public int speed;
        public List<LifesAirplane> lifesAirplanes;
        public static int lifesCount = 3;
        public List<Bullet> bullets;
        public static int bulletCount;

        public Player() { }

        public Player(Image playerImage, int x, int y, Size size)
        {
            this.playerImage = playerImage;
            this.x = x;
            this.y = y;
            this.size = size;
            speed = 15;
            lifesAirplanes = new List<LifesAirplane>();
            bullets = new List<Bullet>();
        }

        public void MoveUp()
        {
            y -= speed;
        }
        public void MoveDown()
        {
            y += speed;
        }

        public void MoveLeft()
        {
            x -= speed;
        }

        public void MoveRight()
        {
            x += speed;
        }

        public void CreateLifesAirplane(int countLifes)
        {
            LifesAirplane pastLifes = null;
            for(var i = 0; i < countLifes; i++)
            {
                var life = new LifesAirplane();
                life.size = new Size(40, 40);
                if(i!=0)
                {
                    life.position = new Point(pastLifes.position.X + life.size.Width, 0);
                    pastLifes = life;
                }
                else
                {
                    life.position = new Point(0, 0);
                    pastLifes = life;
                }
                lifesAirplanes.Add(life);
            }
        }
    }
}
