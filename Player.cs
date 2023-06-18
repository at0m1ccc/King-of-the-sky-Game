using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private int jerk;
        public List<LifesAirplane> lifesAirplanes;
        public int lifesCount;
        public int maxSplittingBulletCount;
        public int JerkCount;
        public int maxStandartBulletCount;
        public bool blockJerk;
        public static int skin = 1;

        public Player() {}

        public Player(Image playerImage, int x, int y, Size size)
        {
            this.playerImage = playerImage;
            this.x = x;
            this.y = y;
            this.size = size;
            lifesAirplanes = new List<LifesAirplane>();
            jerk = 200;
        }

        public void MoveUp()
        {
            if(y > 0)
                y -= speed;
        }
        public void MoveDown()
        {
            if(y + size.Height < Screen.PrimaryScreen.Bounds.Height)
                y += speed;
        }

        public void MoveLeft()
        {
            if(x > 0)
                x -= speed;
        }

        public void MoveRight()
        {
            if(x + size.Width < Screen.PrimaryScreen.Bounds.Width)
                x += speed;
        }

        public void JerkUp()
        {
            if (y - jerk > 0)
            {
                y -= jerk;
                JerkCount -= 1;
                blockJerk = true;
            }
            else if (y - jerk < 0 && y >=10)
            {
                y = 0;
                JerkCount -= 1;
                blockJerk = true;
            }
            else
                y = 0;
        }

        public void JerkDown()
        {
            if (y + size.Height + jerk < Form.ActiveForm.ClientSize.Height)
            {
                y += jerk;
                JerkCount -= 1;
                blockJerk = true;
            }
            else if (y + size.Height + jerk > Form.ActiveForm.ClientSize.Height && y + size.Height <= Form.ActiveForm.ClientSize.Height - 10)
            {
                y = Form.ActiveForm.ClientSize.Height - size.Height;
                JerkCount -= 1;
                blockJerk = true;
            }
            else
                y = Form.ActiveForm.ClientSize.Height - size.Height;
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
