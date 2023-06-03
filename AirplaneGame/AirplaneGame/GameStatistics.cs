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
        private static Label scores;
        private static Label standartBulletCount;
        private static Label splittingBulletCount;
        private static ProgressBar JerkBlocked;
        private static Label Jerk;
        private static Label JerkCount;

        private void InitStatisticsInGame()
        {
            InitScoresStatistics();
            InitBulletStatistics();
            InitJerksStatistics();
        }

        private void InitObstaclesAndDifficultyLevel()
        {
            DifficultyLevel.ChoiceLevel(player);
            EnemyController.obstacles = new List<Enemy>();
            EnemyController.CreateObstacle();
        }
        private void InitScoresStatistics()
        {
            EnemyController.score = 0;
            EnemyController.limScore = 15;
            scores = new Label
            {
                Size = new Size(150, 30),
                Font = new Font("Times New Roman", 20),
                Text = $"{EnemyController.score}",
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - 100, 0),
                BackColor = Color.Transparent
            };
            Controls.Add(scores);
        }

        private void InitBulletStatistics()
        {
            SplittingBulletController.splittingBullets = new List<SplittingBullet>();
            SplittingBulletController.miniSplittingBulletsUp = new List<SplittingBullet>();
            SplittingBulletController.miniSplittingBulletsDown = new List<SplittingBullet>();
            StandartBulletController.StandartBullets = new List<StandartBullet>();
            standartBulletCount = new Label
            {
                Image = CreateImage.ResizeImage(Directory.sprites["BulletImage.png"], new Size(Screen.PrimaryScreen.Bounds.Width / 26, Screen.PrimaryScreen.Bounds.Height / 20)),
                ImageAlign = ContentAlignment.TopLeft,
                Size = new Size(150, 50),
                Text = $": {player.maxStandartBulletCount}",
                Font = new Font("Times New Roman", 25),
                TextAlign = ContentAlignment.TopCenter,
                BackColor = Color.Transparent
            };
            standartBulletCount.Location = new Point(Screen.PrimaryScreen.Bounds.Width - standartBulletCount.Width * 2 / 3, Screen.PrimaryScreen.Bounds.Height - standartBulletCount.Height);
            Controls.Add(standartBulletCount);
            splittingBulletCount = new Label
            {
                Image = CreateImage.ResizeImage(Directory.sprites["SplittingBullet.png"], new Size(Screen.PrimaryScreen.Bounds.Width / 35, Screen.PrimaryScreen.Bounds.Height / 25)),
                ImageAlign = ContentAlignment.TopLeft,
                Size = new Size(150, 50),
                Text = $": {player.maxSplittingBulletCount}",
                Font = new Font("Tomes New Roman", 25),
                TextAlign = ContentAlignment.TopCenter,
                BackColor = Color.Transparent
            };
            splittingBulletCount.Location = new Point(standartBulletCount.Location.X - splittingBulletCount.Size.Width, standartBulletCount.Location.Y);
            Controls.Add(splittingBulletCount);
        }

        private void InitJerksStatistics()
        {
            JerkCount = new Label
            {
                Size = new Size(200, 30),
                Font = new Font("Times New Roman", 21),
                Text = $"Jerks left: {player.JerkCount}",
                TextAlign = ContentAlignment.TopLeft,
                Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - 30),
                BackColor = Color.Transparent,
            };
            Controls.Add(JerkCount);

            Jerk = new Label
            {
                Size = new Size(345, 30),
                Font = new Font("Times New Roman", 21),
                Text = $"You can use the jerk through:",
                TextAlign = ContentAlignment.TopLeft,
                Location = new Point(JerkCount.Width, JerkCount.Location.Y),
                BackColor = Color.Transparent,
                Visible = false
            };
            Controls.Add(Jerk);

            JerkBlocked = new ProgressBar
            {
                Visible = false,
                Size = new Size(Size.Width / 25, Size.Height / 35),
                Location = new Point(Jerk.Location.X + Jerk.Width, JerkCount.Location.Y),
                Value = 0,
                Maximum = 5000,
                Style = ProgressBarStyle.Continuous
            };

            Controls.Add(JerkBlocked);
        }
    }
}
