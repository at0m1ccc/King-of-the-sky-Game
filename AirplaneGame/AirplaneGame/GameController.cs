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
        private static KeyEventArgs KeyAD;
        private static KeyEventArgs KeyWS;
        private static KeyEventArgs KeyQE;
        private static KeyEventArgs KeyF;
        private static KeyEventArgs KeySpace;

        private void Keyboard()
        {
            KeyAD = new KeyEventArgs(Keys.Z);
            KeyWS = new KeyEventArgs(Keys.Z);
            KeyQE = new KeyEventArgs(Keys.Z);
            KeyF = new KeyEventArgs(Keys.Z);
            KeySpace = new KeyEventArgs(Keys.Z);
            KeyDown += (s, e) =>
            {
                if (e.KeyData.ToString() == "W" || e.KeyData.ToString() == "S")
                    KeyWS = e;
                else if (e.KeyData.ToString() == "A" || e.KeyData.ToString() == "D")
                    KeyAD = e;
                else if ((e.KeyData.ToString() == "Q" || e.KeyData.ToString() == "E") && player.JerkCount > 0)
                    KeyQE = e;
                else if (e.KeyData.ToString() == "F" && !isStandartBulletActive)
                {
                    isStandartBulletActive = true;
                    StandartBulletController.CreateBullet(player);
                    standartBulletCount.Text = $": {player.maxStandartBulletCount}";
                }
                else if(e.KeyData.ToString() == "Space" && !isSplittingBulletActive)
                {
                    isSplittingBulletActive = true;
                    SplittingBulletController.CreateBullet(player);
                    splittingBulletCount.Text = $": {player.maxSplittingBulletCount}";
                }
            };

            KeyUp += (s, e) =>
            {
                if ((e.KeyData.ToString() == "W" && KeyWS.KeyData.ToString() != "S") || (e.KeyData.ToString() == "S" && KeyWS.KeyData.ToString() != "W"))
                    KeyWS = new KeyEventArgs(Keys.Z);
                else if ((e.KeyData.ToString() == "A" && KeyAD.KeyData.ToString() != "D") || (e.KeyData.ToString() == "D" && KeyAD.KeyData.ToString() != "A"))
                    KeyAD = new KeyEventArgs(Keys.Z);
                else if (((e.KeyData.ToString() == "Q" && e.KeyData.ToString() != "E") || (e.KeyData.ToString() != "Q" && e.KeyData.ToString() == "E")) && player.JerkCount > 0)
                    KeyQE = new KeyEventArgs(Keys.Z);
                if (e.KeyData.ToString() == "Escape" && !PauseActive)
                {
                    Pause();
                }
                if(e.KeyData.ToString() == "F")
                {
                    isStandartBulletActive = false;
                }
                if (e.KeyData.ToString() == "Space")
                {
                    isSplittingBulletActive = false;
                }
            };
        }
    }
}
