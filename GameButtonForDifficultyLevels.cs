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
        private Button ChooseLevelDifficulty;

        private void InitButtonForLevelDifficulty(string nameLevel, Size size, Point position, int complexity)
        {
            ChooseLevelDifficulty = new Button
            {
                Text = $"{nameLevel}",
                Font = new Font("Times New Roman", 20),
                BackColor = Color.White,
                ForeColor = Color.DarkRed,
                Size = size,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = position
            };
            Controls.Add(ChooseLevelDifficulty);
            ChooseLevelDifficulty.Click += (s, e) =>
            {
                DifficultyLevel.complexity = complexity;
                InitMainMenu();
            };
        }
    }
}
