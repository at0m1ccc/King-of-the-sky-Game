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
        private static int firstLaunch;

        private void InitMainMenu()
        {
            Controls.Clear();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            Directory.sprites = new Dictionary<string, Bitmap>();
            Directory.MakeDir();
            gameView = new GameView();
            BackgroundImage = CreateImage.ResizeImage(Directory.sprites["MenuImage.png"], Screen.PrimaryScreen.Bounds.Size);
            InitNameAndImage();
            InitMenuButtons();
            InitStatisticsInMenu();
            Resize += new EventHandler(ResizeGame);
        }

        private void ResizeGame(object sender, EventArgs e)
        {
            star.Size = new Size(Width / 7, Height / 5);
            star.Location = Location = new Point(Width / 2 - imageStar.Width/2, 10);
            NameGame.Location = new Point(star.Location.X - imageStar.Width / 10, star.Bottom + Height / 25);
            NameGame.Size = new Size(300, 50);
            startGameButton.Location = new Point(NameGame.Location.X, NameGame.Bottom + Height / 25);
            startGameButton.Size = new Size(Width / 5, Height / 10);
            DifficultyLevelButton.Location = new Point(NameGame.Location.X, startGameButton.Bottom + Height / 25);
            DifficultyLevelButton.Size = new Size(Width / 5, Height / 10);
            SkinStoreButton.Location = new Point(DifficultyLevelButton.Location.X, DifficultyLevelButton.Bottom + Height / 25);
            SkinStoreButton.Size = new Size(Width / 5, Height / 10);
            exitGameButton.Location = new Point(SkinStoreButton.Location.X, SkinStoreButton.Bottom + Height / 25);
            exitGameButton.Size = new Size(Width / 5, Height / 10);
            highScore.Size = new Size(400, star.Height / 4);
            highScore.Location = new Point(NameGame.Location.X, exitGameButton.Bottom + Height / 25);
        }
    }
}
