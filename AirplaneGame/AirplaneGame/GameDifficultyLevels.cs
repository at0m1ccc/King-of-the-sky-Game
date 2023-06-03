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
        private static Label LevelDifficulty;

        private void InitLevelDifficulty()
        {
            LevelDifficulty = new Label
            {
                BackColor = Color.Transparent,
                Text = "Select your difficulty",
                Font = new Font("Times New Roman", 20),
                TextAlign = ContentAlignment.TopCenter,
                Size = new Size(300, 40)
            };
            LevelDifficulty.Location = new Point(Screen.PrimaryScreen.Bounds.Width/2 - LevelDifficulty.Width/2, Height / 4 + LevelDifficulty.Height / 4);
            Controls.Add(LevelDifficulty);
            InitButtonForLevelDifficulty("Easy", new Size(LevelDifficulty.Width, LevelDifficulty.Height * 2),
                new Point(LevelDifficulty.Location.X, LevelDifficulty.Bottom + Height / 20), 1);
            InitButtonForLevelDifficulty("Medium", new Size(LevelDifficulty.Width, LevelDifficulty.Height * 2),
                new Point(LevelDifficulty.Location.X, LevelDifficulty.Bottom + LevelDifficulty.Height*2 + Height*2 / 20), 2);
            InitButtonForLevelDifficulty("Hard", new Size(LevelDifficulty.Width, LevelDifficulty.Height * 2),
                new Point(LevelDifficulty.Location.X, LevelDifficulty.Bottom + LevelDifficulty.Height * 4 + Height*3 / 20), 3);
            InitButtonForLevelDifficulty("God", new Size(LevelDifficulty.Width, LevelDifficulty.Height * 2),
                new Point(LevelDifficulty.Location.X, LevelDifficulty.Bottom + LevelDifficulty.Height * 6 + Height*4 / 20), 4);
        }
    }
}
