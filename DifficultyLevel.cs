using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneGame
{
    public class DifficultyLevel
    {
        public static int maxCountWarior;
        public static int complexity = 1;
        public static void ChoiceLevel(Player player)
        {
            switch(complexity)
            {
                case 1:
                    player.lifesCount = 5;
                    player.speed = 13;
                    player.JerkCount = 10;
                    player.maxStandartBulletCount = 10;
                    player.maxSplittingBulletCount = 10;
                    maxCountWarior = 2;
                    break;
                case 2:
                    player.lifesCount = 3;
                    player.speed = 12;
                    player.JerkCount = 5;
                    player.maxStandartBulletCount = 5;
                    player.maxSplittingBulletCount = 5;
                    maxCountWarior = 3;
                    break;
                case 3:
                    player.lifesCount = 1;
                    player.speed = 11;
                    player.JerkCount = 3;
                    player.maxStandartBulletCount = 3;
                    player.maxSplittingBulletCount = 3;
                    maxCountWarior = 4;
                    break;
                case 4:
                    player.lifesCount = 1;
                    player.speed = 9;
                    player.JerkCount = 0;
                    player.maxStandartBulletCount = 0;
                    player.maxSplittingBulletCount = 0;
                    maxCountWarior = 4;
                    break;
            }

        }
    }
}
