using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneGame
{
    public class StandartBullet
    {
        public Point position;
        public Size size;
        private Image imageBullet;
        public int speed;

        public StandartBullet()
        {
            speed = 20;
            size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.052), (int)(Screen.PrimaryScreen.Bounds.Height * 0.046));
            imageBullet = CreateImage.ResizeImage(Directory.sprites["StandartBullet.png"], size);
        }

        public void SpriteDrawStandartBullet(Graphics gr)
        {
            gr.DrawImage(imageBullet, position.X, position.Y, size.Width, size.Height);
        }
    }
}