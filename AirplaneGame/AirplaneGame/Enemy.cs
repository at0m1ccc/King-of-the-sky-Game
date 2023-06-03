using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneGame
{
    public class Enemy
    {
        public Image imageObstacle;
        public int x, y;
        public Size size;
        public int speed;
        public string fileName;
        public GraphicsPath grPath;
        public Region hitbox;

        public Enemy()
        {
            speed = 10;
        }

        public void SpriteDraw(Graphics gr)
        {
            gr.DrawImage(imageObstacle, x, y, size.Width, size.Height);
        }

        public bool CheckCrash(Player player)
        {
            if (hitbox.IsVisible(new Point(player.x, player.y)) 
                || hitbox.IsVisible(new Point(player.x + player.size.Width*34/100, player.y + player.size.Height* 3 / 100))
                || hitbox.IsVisible(new Point(player.x + player.size.Width/ 2, player.y+ player.size.Height* 26 /100))
                || hitbox.IsVisible(new Point(player.x + player.size.Width * 68 / 100, player.y + player.size.Height * 14 / 100))
                || hitbox.IsVisible(new Point(player.x + player.size.Width * 9 / 10, player.y + player.size.Height * 33 / 100))
                || hitbox.IsVisible(new Point(player.x + player.size.Width*86/100, player.y + player.size.Height / 3))
                || hitbox.IsVisible(new Point(player.x + player.size.Width, player.y + player.size.Height /2))
                || hitbox.IsVisible(new Point(player.x + player.size.Width*88/100, player.y + player.size.Height *2/3))
                || hitbox.IsVisible(new Point(player.x + player.size.Width * 81 / 100, player.y + player.size.Height * 3 / 4))
                || hitbox.IsVisible(new Point(player.x + player.size.Width * 52 / 100, player.y + player.size.Height * 82 / 100))
                || hitbox.IsVisible(new Point(player.x + player.size.Width  * 48/ 100, player.y + player.size.Height*95/100))
                || hitbox.IsVisible(new Point(player.x + player.size.Width / 4, player.y + player.size.Height))
                || hitbox.IsVisible(new Point(player.x + player.size.Width /5, player.y + player.size.Height / 2))
                || hitbox.IsVisible(new Point(player.x + player.size.Width / 5, player.y + player.size.Height * 18 / 100)))
            {
                return CheckPlayerDead(player);
            }
            return false;
        }

        private bool CheckPlayerDead(Player player)
        {
            if (player.lifesAirplanes.Count > 1)
            {
                player.lifesAirplanes.RemoveAt(player.lifesAirplanes.Count - 1);
                EnemyController.ReCreateObstacle(this, 0, 0, new Random());
                return false;
            }
            else if (player.lifesAirplanes.Count == 1)
            {
                player.lifesAirplanes.RemoveAt(player.lifesAirplanes.Count - 1);
                return true;
            }
            else
                return true;
        }

        public bool HitWIthStandartBullet(StandartBullet bullet)
        {
            if (hitbox.IsVisible(new Point(bullet.position.X, bullet.position.Y+bullet.size.Height/2))
                || hitbox.IsVisible(new Point(bullet.position.X+bullet.size.Width*4/10, bullet.position.Y))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 55 / 100, bullet.position.Y + bullet.size.Height*3/10))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 9 / 10, bullet.position.Y + bullet.size.Height * 29 / 100))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width, bullet.position.Y + bullet.size.Height / 2))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 9 / 10, bullet.position.Y + bullet.size.Height * 7 / 10))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 55 / 100, bullet.position.Y + bullet.size.Height * 7 / 10))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 41 / 100, bullet.position.Y + bullet.size.Height)))
                return true;
            return false;
        }

        public bool HitWIthSplittingBullet(SplittingBullet bullet)
        {
            if (hitbox.IsVisible(new Point(bullet.position.X, bullet.position.Y + bullet.size.Height / 2))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 4 / 10, bullet.position.Y))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 55 / 100, bullet.position.Y + bullet.size.Height * 3 / 10))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 9 / 10, bullet.position.Y + bullet.size.Height * 29 / 100))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width, bullet.position.Y + bullet.size.Height / 2))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 9 / 10, bullet.position.Y + bullet.size.Height * 7 / 10))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 55 / 100, bullet.position.Y + bullet.size.Height * 7 / 10))
                || hitbox.IsVisible(new Point(bullet.position.X + bullet.size.Width * 41 / 100, bullet.position.Y + bullet.size.Height)))
                return true;
            return false;
        }
    }
}
