using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneGame
{
    public partial class Form1 : Form
    {
        private static Label SkinStore;
        private static Button ExitStore;

        private void InitSkinStore()
        {
            GameView.background = null;
            BackgroundImage = CreateImage.ResizeImage(Directory.sprites["hangar.png"], Screen.PrimaryScreen.Bounds.Size);
            SkinStore = new Label
            {
                BackColor = Color.Transparent,
                Text = "Skin Store",
                Font = new Font("Times New Roman", 20),
                ForeColor = Color.Yellow,
                TextAlign = ContentAlignment.TopCenter,
                Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.1),(int)(Screen.PrimaryScreen.Bounds.Height * 0.037)),
                Location = new Point(((int)(Screen.PrimaryScreen.Bounds.Width * 0.5)) - (int)(Screen.PrimaryScreen.Bounds.Width * 0.1)/2, (int)(Screen.PrimaryScreen.Bounds.Height * 0.005))
            };
            Controls.Add(SkinStore);

            InitSkinInStore(0, new Point(Screen.PrimaryScreen.Bounds.Width / 4, Screen.PrimaryScreen.Bounds.Width / 6), 1, "Planet Express");
            InitSkinInStore(50, new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Width / 6), 2, "Halo airplane");
            InitSkinInStore(200, new Point(Screen.PrimaryScreen.Bounds.Width / 4, Screen.PrimaryScreen.Bounds.Width / 3), 3, "Cyclops airplane");
            InitSkinInStore(500, new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Width / 3), 4, "Flying Weapons");

            ExitStore = new Button
            {
                Text = "Exit to menu",
                Font = new Font("Times New Roman", 16),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.TopCenter,
                Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.1), Screen.PrimaryScreen.Bounds.Height / 25),
                Location = new Point(0, 0)
            };
            Controls.Add(ExitStore);
            ExitStore.Click += (s, ev) =>
            {
                InitMainMenu();
            };
        }
    }
}
