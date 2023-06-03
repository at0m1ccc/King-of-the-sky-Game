using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneGame
{
    public static class Directory
    {
        public static Dictionary<string, Bitmap> sprites;

        public static void MakeDir(DirectoryInfo directoryImages = null)
        {
            var wayToFile = @"..\..\ImagesForGame\";
            if (directoryImages == null)
                directoryImages = new DirectoryInfo(wayToFile);
            foreach (var image in directoryImages.GetFiles("*.png"))
                sprites[image.Name] = (Bitmap)Image.FromFile(image.FullName);
        }
    }
}
