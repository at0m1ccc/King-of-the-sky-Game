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
        private static Timer DrawLifes;
        private static Image playerImage;
        private static Image background;
        public Player player;
        private static int startDraw;
        private static List<Timer> timers;
        private static KeyEventArgs KeyAD;
        private static KeyEventArgs KeyWS;
        private static Label scores;

        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            Directory.sprites = new Dictionary<string, Bitmap>();
            Directory.MakeDir("ImagesForGame");
            timers = new List<Timer>();
            WindowState = FormWindowState.Maximized;
            playerImage = Directory.sprites["airplane1.png"];
            player = new Player(playerImage, Width / 16, Height / 2, new Size(playerImage.Width, playerImage.Height));
            background = Directory.sprites["background.png"];
            startDraw = 5;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Paint += new PaintEventHandler(OnPaint);
            ObstaclesController.obstacles = new List<Obstacle>();
            ObstaclesController.CreateObstacle();
            ObstaclesController.score = 0;
            ObstaclesController.limScore = 30;
            Keyboard();
            scores = new Label
            {
                Size = new Size(150, 30),
                Font = new Font("Times New Roman", 20),
                Text = $"{ObstaclesController.score}",
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - 100, 0),
                ImageAlign = ContentAlignment.TopLeft,
                BackColor = Color.Transparent
            };
            Controls.Add(scores);

            var PlayerMoveTimer = new Timer
            {
                Interval = 10
            };
            PlayerMoveTimer.Tick += MoveTimer_Tick;
            timers.Add(PlayerMoveTimer);

            var ObstaclesMoveTimer = new Timer
            {
                Interval = 10
            };
            ObstaclesMoveTimer.Tick += TickObstaclesMoveTimer;
            timers.Add(ObstaclesMoveTimer);

            var ObstaclesSpeedAndScoreTimer = new Timer
            {
                Interval = 1000
            };
            ObstaclesSpeedAndScoreTimer.Tick += TickObstaclesSpeedAndScoreTimer;
            timers.Add(ObstaclesSpeedAndScoreTimer);

            var CheckContact = new Timer { Interval = 10};
            CheckContact.Tick += TimerCheckContact;
            timers.Add(CheckContact);
            DrawLifes = new Timer { Interval = 10 };
            DrawLifes.Tick += TimerDrawLifes;
            timers.Add(DrawLifes);

            foreach (var timer in timers)
                timer.Start();
        }

        int StartDraw
        {
            get => startDraw;
            set
            {
                startDraw = value;
                if (startDraw < -background.Width) startDraw += background.Width;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            for (int i = 0; i <= 2; i++)
            {
                gr.DrawImage(background, -StartDraw + background.Width * i, 0);
            }
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(player.currentShot), player.size), GraphicsUnit.Pixel);
            foreach (var obs in ObstaclesController.obstacles)
            {
                obs.SpriteDraw(gr);
            }

            foreach (var life in player.lifesAirplanes)
            {
                life.Draw(gr);
            }
        }

        private void Keyboard()
        {
            KeyAD = new KeyEventArgs(Keys.Z);
            KeyWS = new KeyEventArgs(Keys.Z);
            KeyDown += (s, e) =>
            {
                if (e.KeyData.ToString() == "W" || e.KeyData.ToString() == "S")
                    KeyWS = e;
                else if (e.KeyData.ToString() == "A" || e.KeyData.ToString() == "D")
                    KeyAD = e;
            };
            KeyUp += (s, e) =>
            {
                if ((e.KeyData.ToString() == "W" && KeyWS.KeyData.ToString() != "S") || (e.KeyData.ToString() == "S" && KeyWS.KeyData.ToString() != "W"))
                    KeyWS = new KeyEventArgs(Keys.Z);
                else if ((e.KeyData.ToString() == "A" && KeyAD.KeyData.ToString() != "D") || (e.KeyData.ToString() == "D" && KeyAD.KeyData.ToString() != "A"))
                    KeyAD = new KeyEventArgs(Keys.Z);
            };
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            
            StartDraw += 3;
            if (KeyAD.KeyData.ToString() != "Z" || KeyWS.KeyData.ToString() != "Z")
            {
                Controller.player = player;
                Controller.Move(KeyWS.KeyData.ToString(), KeyAD.KeyData.ToString());
            }
        }

        private void TickObstaclesMoveTimer(object sender, EventArgs e)
        {
            Invalidate();
            ObstaclesController.MoveObstacles(player);
            if (ObstaclesController.checker == false)
            {
                GameOver();
            }
        }

        private void TickObstaclesSpeedAndScoreTimer(object sender, EventArgs e)
        {
            ObstaclesController.score += 1;
            scores.Text = $"{ObstaclesController.score}";
            ObstaclesController.UpSpeed();
        }

        private void TimerCheckContact(object sender, EventArgs e)
        {
            ObstaclesController.CheckContact(player);
        }

        private void TimerDrawLifes(object sender, EventArgs e)
        {
            player.CreateLifesAirplane(Player.lifesCount);
            DrawLifes.Stop();
        }

        private void GameOver()
        {
            StopTimers();
            ObstaclesController.checker = true;
            var res = MessageBox.Show("Вы проиграли!!!", "Game over", MessageBoxButtons.OK);
            if (res == DialogResult.OK)
            {
                Controls.Clear();
                Dispose();
            }
        }

        private void StopTimers()
        {
            foreach (var timer in timers)
                timer.Stop();
        }
    }
}
