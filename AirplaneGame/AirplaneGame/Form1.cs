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
        private static Image playerImage;
        private Player player;
        private GameView gameView;

        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            InitMainMenu();
        }

        private void Init()
        {
            Controls.Clear();
            PauseActive = false;
            BackgroundImage = null;
            playerImage = CreateImage.ResizeImage(Directory.sprites[$"airplane{Player.skin}.png"], new Size((int)(Screen.PrimaryScreen.Bounds.Width* 0.1442), (int)(Screen.PrimaryScreen.Bounds.Height*0.09)));
            player = new Player(playerImage, Width / 16, Height / 2, new Size(playerImage.Width, playerImage.Height));
            GameView.background = CreateImage.ResizeImage(Directory.sprites["background.png"], Screen.PrimaryScreen.Bounds.Size);
            Keyboard();
            InitObstaclesAndDifficultyLevel();
            InitStatisticsInGame();
            InitTimers();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            gameView.DrawBackground(gr);
            gameView.DrawPlayer(player, gr);
            gameView.DrawStandartBullet(gr);
            gameView.DrawSplittingBullet(gr);
            gameView.DrawLifesPlayer(player, gr);
            gameView.DrawObstacles(gr);
        }
    }
}