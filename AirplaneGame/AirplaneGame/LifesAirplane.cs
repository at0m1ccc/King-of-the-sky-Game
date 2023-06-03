using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneGame
{
    public class LifesAirplane
    {
        public Point position;
        public Size size;
        readonly Image imageLife;

        public LifesAirplane()
        {
            imageLife = CreateImage.ResizeImage(Directory.sprites["LifesAirplane.png"], new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.469), (int)(Screen.PrimaryScreen.Bounds.Height * 0.74)));
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(imageLife, position.X, position.Y, size.Width, size.Height);
        }
    }
}
