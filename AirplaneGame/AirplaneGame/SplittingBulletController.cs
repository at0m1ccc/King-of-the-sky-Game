using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneGame
{
    public static class SplittingBulletController
    {
        public static List<SplittingBullet> splittingBullets;
        public static List<SplittingBullet> miniSplittingBulletsUp;
        public static List<SplittingBullet> miniSplittingBulletsDown;

        public static void MoveSplittingtBullet()
        {
            for (var i = 0; i < splittingBullets.Count; i++)
            {
                splittingBullets[i].position.X += splittingBullets[i].speed;
                splittingBullets[i].position.Y += splittingBullets[i].gravitation;
                if (splittingBullets[i].position.X > Screen.PrimaryScreen.Bounds.Width
                    || splittingBullets[i].position.Y > Screen.PrimaryScreen.Bounds.Height)
                {
                    splittingBullets.Remove(splittingBullets[i]);
                }
            }
        }

        public static void CreateBullet(Player player)
        {
            if (player.maxSplittingBulletCount != 0)
            {
                var bullet = new SplittingBullet();
                bullet.position = new Point(player.x + player.size.Width * 10 / 14, (player.y + (player.size.Height * 10 / 14) / 2));
                splittingBullets.Add(bullet);
                player.maxSplittingBulletCount -= 1;
            }
        }

        public static void MakeMiniBulletGoUp(SplittingBullet bullet)
        {
            var miniSplittingBulletUp = new SplittingBullet();
            miniSplittingBulletUp.size = new Size(bullet.size.Width / 2, bullet.size.Height / 2);
            miniSplittingBulletUp.position = bullet.position;
            miniSplittingBulletUp.split = bullet.split;
            miniSplittingBulletsUp.Add(miniSplittingBulletUp);
        }

        public static void MakeMiniBulletGoDown(SplittingBullet bullet)
        {
            var miniBulletsDown = new SplittingBullet();
            miniBulletsDown.size = new Size(bullet.size.Width / 2, (bullet.size.Height / 2));
            miniBulletsDown.position = bullet.position;
            miniBulletsDown.split = bullet.split+1;
            miniSplittingBulletsDown.Add(miniBulletsDown);
        }

        public static void MoveUpMiniBullet()
        {
            for (int i = 0; i < miniSplittingBulletsUp.Count; i++)
            {
                miniSplittingBulletsUp[i].position.Y -= miniSplittingBulletsUp[i].speed;
                miniSplittingBulletsUp[i].position.X += miniSplittingBulletsUp[i].gravitation;
                if (miniSplittingBulletsUp[i].position.Y + miniSplittingBulletsUp[i].size.Height < 0)
                    miniSplittingBulletsUp.Remove(miniSplittingBulletsUp[i]);
            }
        }

        public static void MoveDownMiniBullet()
        {
            for (int i = 0; i < miniSplittingBulletsDown.Count; i++)
            {
                miniSplittingBulletsDown[i].position.Y += miniSplittingBulletsDown[i].speed;
                miniSplittingBulletsDown[i].position.X += miniSplittingBulletsDown[i].gravitation;
                if (miniSplittingBulletsDown[i].position.Y + miniSplittingBulletsDown[i].size.Height > Screen.PrimaryScreen.Bounds.Height)
                    miniSplittingBulletsDown.Remove(miniSplittingBulletsDown[i]);
            }
        }
    }
}
