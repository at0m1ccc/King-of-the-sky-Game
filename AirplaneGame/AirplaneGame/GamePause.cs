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
        private bool PauseActive;
        private Label PauseLabel;

        private void Pause()
        {
            StopTimers();
            if (EnemyController.score > EnemyController.bestScore)
                EnemyController.bestScore = EnemyController.score;
            PauseActive = true;
            WindowPause();
        }

        private void WindowPause()
        {
            var imagePause = CreateImage.ResizeImage(Directory.sprites["Pause.png"], new Size(Size.Width / 6, Size.Height / 7));
            PauseLabel = new Label
            {
                BackColor = Color.Transparent,
                Image = imagePause,
                Size = imagePause.Size,
                ImageAlign = ContentAlignment.TopCenter
            };
            PauseLabel.Location = new Point(Width / 2 - PauseLabel.Width / 2, Height / 4 + PauseLabel.Height / 4);
            MakeContinueButton(PauseLabel);
            MakeExitToMenuButton(PauseLabel, ContinueButton);
            Controls.Add(PauseLabel);
        }
    }
}
