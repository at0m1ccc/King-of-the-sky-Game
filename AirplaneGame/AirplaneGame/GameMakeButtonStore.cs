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
        private Label priceSkin;
        private Label skinImage;
        private Button BuySkin;
        private void InitSkinInStore(int price, Point position, int numberSkin, string nameSkin)
        {
            InitSkinImage(numberSkin, nameSkin, price, position);
            InitPriceSkin(price);
            InitBuySkin(price, numberSkin);
        }

        private void InitSkinImage(int numberSkin, string nameSkin, int price, Point position)
        {
            skinImage = new Label
            {
                Image = CreateImage.ResizeImage(Directory.sprites[$"airplane{numberSkin}.png"],
                new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.1442), (int)(Screen.PrimaryScreen.Bounds.Height * 0.09))),
                ImageAlign = ContentAlignment.TopCenter,
                Text = $"{nameSkin}",
                ForeColor = EnemyController.bestScore >= price ? Color.Yellow : Color.Red,
                Font = new Font("Times New Roman", 20),
                TextAlign = ContentAlignment.BottomCenter,
                BackColor = Color.Transparent,
                Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.15), (int)(Screen.PrimaryScreen.Bounds.Height * 0.15)),
                Location = position
            };
            Controls.Add(skinImage);
        }

        private void InitPriceSkin(int price)
        {
            priceSkin = new Label
            {
                Text = $"Price: {price}",
                Font = new Font("Times New Roman", 20),
                ForeColor = Color.Green,
                Size = new Size(skinImage.Size.Width*2/3, skinImage.Size.Width/9),
                Location = new Point(skinImage.Location.X + skinImage.Image.Size.Width / 4, skinImage.Bottom+10),
                BackColor = Color.Transparent
            };
            Controls.Add(priceSkin);
        }

        private void InitBuySkin(int price, int numberSkin)
        {
            BuySkin = new Button
            {
                Text = price<=EnemyController.bestScore? "Used" : "Locked",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.White,
                Size = new Size(Screen.PrimaryScreen.Bounds.Width / 14, Screen.PrimaryScreen.Bounds.Height / 20),
                TextAlign = ContentAlignment.BottomCenter,
                Location = new Point(skinImage.Location.X + skinImage.Image.Size.Width / 4, priceSkin.Bottom + 10),
            };
            Controls.Add(BuySkin);
            BuySkin.Click += (s, ev) =>
            {
                if(EnemyController.bestScore>=price)
                    Player.skin = numberSkin;
            };
        }
    }
}
