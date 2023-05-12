using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneGame
{
    public static class Controller
    {
        public static Player player;

        public static void Move(string KeyWS, string KeyAD)
        {
            switch (KeyWS)
            {
                case "W":
                    player.MoveUp();
                    break;
                case "S":
                    player.MoveDown();
                    break;
            }
            switch (KeyAD)
            {
                case "D":
                    player.MoveRight();
                    player.currentShot = 1;
                    break;
                case "A":
                    player.MoveLeft();
                    player.currentShot = 0;
                    break;
            }
            switch(MouseButtons.Left)

        }
    }
}