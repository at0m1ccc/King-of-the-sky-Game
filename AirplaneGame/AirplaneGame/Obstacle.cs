using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneGame
{
    public class Obstacle
    {
        public Image imageObstacle;
        public int x, y;
        public Size size;
        public int speed;

        public Obstacle()
        {
            speed = 10;
        }

        public void SpriteDraw(Graphics gr)
        {
            gr.DrawImage(imageObstacle, x, y, size.Width, size.Height);
        }

        public bool CheckCrash(Player player)
        {
            if (x < player.x + player.size.Width && player.x < x + size.Width
                && y < player.y + player.size.Height && player.y < y + size.Height)
                return CheckDead(player);
            return false;
        }

        public bool CheckDead(Player player)
        {
            if (player.lifesAirplanes.Count > 1)
            {
                player.lifesAirplanes.RemoveAt(player.lifesAirplanes.Count - 1);
                ObstaclesController.ReCreateObstacle(this, 0, 0, new Random());
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
    }
}
