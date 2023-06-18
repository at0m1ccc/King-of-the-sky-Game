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
        private static List<Timer> timers;
        private Timer DrawLifes;
        private Timer TimerJerkBlocked;
        private Timer PlayerMoveTimer;
        private Timer ObstaclesMoveTimer;
        private Timer ObstaclesSpeedAndScoreTimer;
        private Timer CheckContact;
        private Timer JerkMove;
        private bool isStandartBulletActive;
        private bool isSplittingBulletActive;

        private void InitTimers()
        {
            timers = new List<Timer>();
            PlayerMoveTimer = new Timer { Interval = 10 };
            PlayerMoveTimer.Tick += MoveTimer_Tick;
            timers.Add(PlayerMoveTimer);

            ObstaclesMoveTimer = new Timer { Interval = 10 };
            ObstaclesMoveTimer.Tick += TickEnemyAndBulletMoveTimer;
            timers.Add(ObstaclesMoveTimer);

            ObstaclesSpeedAndScoreTimer = new Timer { Interval = 1000 };
            ObstaclesSpeedAndScoreTimer.Tick += TickEnemySpeedAndStatisticsTimer;
            timers.Add(ObstaclesSpeedAndScoreTimer);

            CheckContact = new Timer { Interval = 1 };
            CheckContact.Tick += TimerCheckContact;
            timers.Add(CheckContact);

            JerkMove = new Timer { Interval = 1 };
            JerkMove.Tick += JerkMoveAndJerkCountTick;
            timers.Add(JerkMove);

            TimerJerkBlocked = new Timer { Interval = 1 };
            TimerJerkBlocked.Tick += TimerBlockedJerk_Tick;

            StartTimers();

            DrawLifes = new Timer { Interval = 10 };
            DrawLifes.Tick += TimerDrawLifes;
            DrawLifes.Start();
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            GameView.StartDraw += 2;
            Controller.player = player;
            if (KeyAD.KeyData.ToString() != "Z" || KeyWS.KeyData.ToString() != "Z")
            {
                Controller.Move(KeyWS.KeyData.ToString(), KeyAD.KeyData.ToString());
            }
        }

        private void JerkMoveAndJerkCountTick(object sender, EventArgs e)
        {
            if (player.blockJerk)
            {
                timers.Add(TimerJerkBlocked);
                TimerJerkBlocked.Start();
                Jerk.Visible = true;
                JerkBlocked.Visible = true;
                JerkCount.Text = $"Jerks left: {player.JerkCount}";
            }
            if (KeyQE.KeyData.ToString() != "Z" && player.JerkCount != 0 && !player.blockJerk)
            {
                Controller.JerkMove(KeyQE.KeyData.ToString());
            }
        }

        private void TimerBlockedJerk_Tick(object sender, EventArgs e)
        {
            if (JerkBlocked.Value < 5000)
            {
                JerkBlocked.Value += 20;
            }
            else
            {
                player.blockJerk = false;
                Jerk.Visible = false;
                JerkBlocked.Visible = false;
                JerkBlocked.Value = 0;
                timers.Remove(TimerJerkBlocked);
                TimerJerkBlocked.Stop();
            }
        }

        private void TickEnemyAndBulletMoveTimer(object sender, EventArgs e)
        {
            Invalidate();
            EnemyController.MoveObstacles();
            StandartBulletController.MoveStandartBullet();
            SplittingBulletController.MoveSplittingtBullet();
            SplittingBulletController.MoveDownMiniBullet();
            SplittingBulletController.MoveUpMiniBullet();
            if (EnemyController.checkerWithPlayer == false)
            {
                GameOver();
            }
        }

        private void TickEnemySpeedAndStatisticsTimer(object sender, EventArgs e)
        {
            EnemyController.score += 1;
            scores.Text = $"{EnemyController.score}";
            EnemyController.UpSpeed();
        }

        private void TimerCheckContact(object sender, EventArgs e)
        {
            EnemyController.CheckContactWithPlayer(player);
            for (var i = 0; i < StandartBulletController.StandartBullets.Count; i++)
            {
                EnemyController.CheckContactWithStandartBullets(StandartBulletController.StandartBullets[i]);
            }
            for (var i = 0; i < SplittingBulletController.splittingBullets.Count; i++)
            {
                EnemyController.CheckContactWithSplittingBullets(SplittingBulletController.splittingBullets[i]);
            }
            for (var i = 0; i < SplittingBulletController.miniSplittingBulletsDown.Count; i++)
            {
                EnemyController.CheckContactWithSplittingBullets(SplittingBulletController.miniSplittingBulletsDown[i]);
            }
            for (var i = 0; i < SplittingBulletController.miniSplittingBulletsUp.Count; i++)
            {
                EnemyController.CheckContactWithSplittingBullets(SplittingBulletController.miniSplittingBulletsUp[i]);
            }
        }

        private void TimerDrawLifes(object sender, EventArgs e)
        {
            player.CreateLifesAirplane(player.lifesCount);
            DrawLifes.Stop();
        }

        private void StartTimers()
        {
            foreach (var timer in timers)
                timer.Start();
        }

        private void StopTimers()
        {
            foreach (var timer in timers)
                timer.Stop();
        }
    }
}
