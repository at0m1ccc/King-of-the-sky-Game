using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneGame
{
    public class LifesAirplane
    {
        public Point position;
        public Size size;
        readonly Image imageLife;

        public LifesAirplane()
        {
            imageLife = Directory.sprites["LifesAirplane.png"];
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(imageLife, position.X, position.Y, size.Width, size.Height);
        }
    }
}
