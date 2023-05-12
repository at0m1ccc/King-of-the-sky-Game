using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneGame
{
    public class Bullet
    {
        public int x,y;
        public Size size;
        public Image imageBullet;
        public int speed;

        public Bullet()
        {
            speed = 30;
            imageBullet = Directory.sprites["Bullet"];
        }

        public void SpriteDraw(Graphics gr)
        {
            gr.DrawImage(imageBullet, x, y, size.Width, size.Height);
        }

    }
}
