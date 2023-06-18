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
        private static Button startGameButton;
        private static Button DifficultyLevelButton;
        private static Button SkinStoreButton;
        private static Button exitGameButton;

        private void InitMenuButtons()
        {
            startGameButton = new Button
            {
                Size = new Size(Width / 5, Height / 10),
                Location = new Point(NameGame.Location.X, NameGame.Bottom + Height / 25),
                Text = "Start",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.CadetBlue,
            };
            Controls.Add(startGameButton);
            startGameButton.Click += new EventHandler(StartGame);

            DifficultyLevelButton = new Button
            {
                Location = new Point(NameGame.Location.X, startGameButton.Bottom + Height / 25),
                Size = new Size(Width / 5, Height / 10),
                Text = "Difficulty level",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.CadetBlue,
            };
            Controls.Add(DifficultyLevelButton);
            DifficultyLevelButton.Click += new EventHandler(Level);

            SkinStoreButton = new Button
            {
                Location = new Point(DifficultyLevelButton.Location.X, DifficultyLevelButton.Bottom + Height / 25),
                Size = new Size(Width / 5, Height / 10),
                Text = "Skin Store",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.CadetBlue
            };
            Controls.Add(SkinStoreButton);
            SkinStoreButton.Click += new EventHandler(Store);


            exitGameButton = new Button
            {
                Location = new Point(SkinStoreButton.Location.X, SkinStoreButton.Bottom + Height / 25),
                Size = new Size(Width / 5, Height / 10),
                Text = "Exit the game",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.CadetBlue,
            };
            Controls.Add(exitGameButton);
            exitGameButton.Click += new EventHandler(ExitGame);
        }

        private void StartGame(object sender, EventArgs e)
        {
            if (firstLaunch == 0)
            {
                Controls.Clear();
                firstLaunch++;
                BackgroundImage = CreateImage.ResizeImage(Directory.sprites["Training.png"], Screen.PrimaryScreen.Bounds.Size);
                var readyButton = new Button
                {
                    Size = new Size((Width / 5), Height / 10),
                    Location = new Point(Width * 2 / 4, Height * 2 / 3),
                    Text = "Ready",
                    Font = new Font("Times New Roman", 21),
                    BackColor = Color.Empty
                };
                Controls.Add(readyButton);
                readyButton.Click += (s, ev) =>
                {
                    Init();
                    Paint += new PaintEventHandler(OnPaint);
                };
            }
            else
                Init();
        }

        private void Level(object sender, EventArgs e)
        {
            Controls.Clear();
            InitLevelDifficulty();
        }

        private void Store(object sender, EventArgs e)
        {
            Controls.Clear();
            InitSkinStore();
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
