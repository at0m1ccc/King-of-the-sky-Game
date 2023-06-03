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
        private static Button RestartButton;
        private static Button GoToMenuButton;
        private static Button ContinueButton;

        private void MakeRestartButton(Label MenuLabel)
        {
            RestartButton = new Button
            {
                Text = "Restart",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.White,
                ForeColor = Color.DarkRed,
                Size = new Size(MenuLabel.Width * 2, MenuLabel.Height * 2 / 3),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(MenuLabel.Location.X - MenuLabel.Width / 2, MenuLabel.Bottom + Height / 20)
            };
            Controls.Add(RestartButton);
            RestartButton.Click += (s, e) =>
            {
                PauseActive = false;
                Init();
            };
        }

        private void MakeContinueButton(Label MenuLabel)
        {
            ContinueButton = new Button
            {
                Text = "Continue",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.White,
                ForeColor = Color.DarkRed,
                Size = new Size(MenuLabel.Width * 2, MenuLabel.Height * 2 / 3),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(MenuLabel.Location.X - MenuLabel.Width / 2, MenuLabel.Bottom + Height / 20)
            };
            Controls.Add(ContinueButton);
            ContinueButton.Click += (s, e) =>
            {
                StartTimers();
                PauseActive = false;
                Controls.Remove(MenuLabel);
                Controls.Remove(GoToMenuButton);
                Controls.Remove(ContinueButton);
            };
        }

        private void MakeExitToMenuButton(Label MenuLabel, Button PreviousButton)
        {
            GoToMenuButton = new Button
            {
                Text = "Back to menu",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.White,
                ForeColor = Color.DarkRed,
                Size = new Size(PreviousButton.Width, PreviousButton.Height),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(MenuLabel.Location.X - PreviousButton.Width / 4, PreviousButton.Bottom + Height / 20)
            };
            Controls.Add(GoToMenuButton);
            GoToMenuButton.Click += (s, e) =>
            {
                player.lifesAirplanes.Clear();
                EnemyController.obstacles.Clear();
                StandartBulletController.StandartBullets.Clear();
                SplittingBulletController.splittingBullets.Clear();
                SplittingBulletController.miniSplittingBulletsDown.Clear();
                SplittingBulletController.miniSplittingBulletsUp.Clear();
                timers.Clear();
                GameView.background = null;
                player.playerImage = null;
                InitMainMenu();
            };
        }
    }
}
