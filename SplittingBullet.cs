using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneGame
{
    public class SplittingBullet
    {
        public Point position;
        public Size size;
        private Image imageBullet;
        public int speed;
        public int gravitation;
        public int split;

        public SplittingBullet()
        {
            speed = 11;
            gravitation = 5;
            size = new Size(Screen.PrimaryScreen.Bounds.Width/24, (int)(Screen.PrimaryScreen.Bounds.Height * 0.046));
            imageBullet = CreateImage.ResizeImage(Directory.sprites["SplittingBullet.png"], size);
        }

        public void SpriteDrawSplittingBullet(Graphics gr)
        {
            gr.DrawImage(imageBullet, position.X, position.Y, size.Width, size.Height);
        }
    }
}
