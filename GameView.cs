using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AirplaneGame
{
    public class GameView
    {
        public static Image background;
        private static int startDraw;

        public GameView()
        {
            background = CreateImage.ResizeImage(Directory.sprites["MenuImage.png"], Screen.PrimaryScreen.Bounds.Size);
            startDraw = 0;
        }

        public static int StartDraw
        {
            get => startDraw;
            set
            {
                startDraw = value;
                if (startDraw > Screen.PrimaryScreen.Bounds.Width) startDraw -= background.Width;
            }
        }

        public void DrawPlayer(Player player, Graphics gr)
        {
            if (player.playerImage != null)
                gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(player.currentShot), player.size), GraphicsUnit.Pixel);
        }

        public void DrawObstacles(Graphics gr)
        {
            foreach (var obs in EnemyController.obstacles)
            {
                obs.SpriteDraw(gr);
            }
        }

        public void DrawLifesPlayer(Player player, Graphics gr)
        {
            foreach (var life in player.lifesAirplanes)
            {
                life.Draw(gr);
            }
        }

        public void DrawStandartBullet(Graphics gr)
        {
            foreach (var bullet in StandartBulletController.StandartBullets)
            {
                bullet.SpriteDrawStandartBullet(gr);
            }
        }

        public void DrawSplittingBullet(Graphics gr)
        {
            foreach (var bullet in SplittingBulletController.splittingBullets)
            {
                bullet.SpriteDrawSplittingBullet(gr);
            }

            foreach(var bullet in SplittingBulletController.miniSplittingBulletsUp)
            {
                bullet.SpriteDrawSplittingBullet(gr);
            }

            foreach (var bullet in SplittingBulletController.miniSplittingBulletsDown)
            {
                bullet.SpriteDrawSplittingBullet(gr);
            }
        }

        public void DrawBackground(Graphics gr)
        {
            for (int i = 0; i < 2; i++)
            {
                if (background != null)
                    gr.DrawImage(background, -StartDraw + background.Width * i, 0);
            }
        }
    }
}
