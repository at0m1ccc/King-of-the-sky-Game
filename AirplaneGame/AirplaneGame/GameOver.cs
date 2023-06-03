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
        private static Label GameOverLabel;

        private void GameOver()
        {
            StopTimers();
            GameView.background = null;
            BackgroundImage = CreateImage.ResizeImage(Directory.sprites["GameOver.png"], Screen.PrimaryScreen.Bounds.Size);
            EnemyController.obstacles.Clear();
            StandartBulletController.StandartBullets.Clear();
            SplittingBulletController.splittingBullets.Clear();
            SplittingBulletController.miniSplittingBulletsDown.Clear();
            SplittingBulletController.miniSplittingBulletsUp.Clear();
            Controls.Clear();
            if (EnemyController.score > EnemyController.bestScore)
                EnemyController.bestScore = EnemyController.score;
            EnemyController.checkerWithPlayer = true;
            PauseActive = true;
            player.playerImage = null;
            WindowOfLoss();
        }

        private void WindowOfLoss()
        {
            var gameOverImage = CreateImage.ResizeImage(Directory.sprites["Text.png"], new Size(Screen.PrimaryScreen.Bounds.Width/6, Screen.PrimaryScreen.Bounds.Height/5));
            GameOverLabel = new Label
            {
                Image = gameOverImage,

                ImageAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };
            GameOverLabel.Size = GameOverLabel.Image.Size;
            GameOverLabel.Location = new Point(Width / 2 - GameOverLabel.Width /2, Height / 4);
            Controls.Add(GameOverLabel);
            MakeRestartButton(GameOverLabel);
            MakeExitToMenuButton(GameOverLabel, RestartButton);
        }
    }
}
