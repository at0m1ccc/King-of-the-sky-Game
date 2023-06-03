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
        private static PictureBox star;
        private static Image imageStar;
        private static Label NameGame;
        private static Label highScore;

        private void InitNameAndImage()
        {
            imageStar = CreateImage.ResizeImage(Directory.sprites["Starrr.png"], new Size((int)(Screen.PrimaryScreen.Bounds.Width*0.1875), (int)(Screen.PrimaryScreen.Bounds.Height*0.333)));
            star = new PictureBox
            {
                Location = new Point(Width / 2 - imageStar.Width / 2, 10),
                Size = new Size(Width / 7, Height / 5),
                BackColor = Color.Transparent,
                Image = imageStar,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            Controls.Add(star);

            NameGame = new Label
            {
                Size = new Size(300, 50),
                Font = new Font("Times New Roman", 31),
                Text = "King of the sky",
                ForeColor = Color.SaddleBrown,
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(star.Location.X - imageStar.Width / 10, star.Bottom + Height / 25),
                BackColor = Color.Transparent
            };
            Controls.Add(NameGame);
        }

        private void InitStatisticsInMenu()
        {
            highScore = new Label
            {
                Size = new Size(400, Height / 25),
                Location = new Point(NameGame.Location.X, exitGameButton.Bottom + Height / 25),
                Text = $"Best score: {EnemyController.bestScore}",
                Font = new Font("Times New Roman", 20),
                TextAlign = ContentAlignment.TopLeft,
                BackColor = Color.Transparent,
            };
            Controls.Add(highScore);
        }
    }
}
