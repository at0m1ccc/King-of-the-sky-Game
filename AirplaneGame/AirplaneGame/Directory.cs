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

        public static void MakeDir(string filename, DirectoryInfo imagesDirectory = null)
        {
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo(filename);
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                sprites[e.Name] = (Bitmap)Image.FromFile(e.FullName);
        }
    }
}
