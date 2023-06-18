using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneGame
{
    public static class StandartBulletController
    {
        public static List<StandartBullet> StandartBullets;

        public static void MoveStandartBullet()
        {
            for(int i = 0; i < StandartBullets.Count; i++)
            {
                StandartBullets[i].position.X += StandartBullets[i].speed;
                if (StandartBullets[i].position.X  > Screen.PrimaryScreen.Bounds.Width)
                {
                    StandartBullets.Remove(StandartBullets[i]);
                }
            }
        }

        public static void CreateBullet(Player player)
        {
            if(player.maxStandartBulletCount != 0)
            {
                StandartBullet bullet = new StandartBullet();
                bullet.position = new Point(player.x + player.size.Width * 10 / 14, (player.y + (player.size.Height * 10 / 14) / 2));
                StandartBullets.Add(bullet);
                player.maxStandartBulletCount -= 1;
            }
        }
    }
}