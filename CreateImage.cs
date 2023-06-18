using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneGame
{
    public static class CreateImage
    {
        public static Bitmap ResizeImage(Image currentImage, Size size)
        {
            Bitmap newImage = new Bitmap(size.Width, size.Height);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(currentImage, new Rectangle(Point.Empty, size));
            }
            return newImage;
        }
    }
}
