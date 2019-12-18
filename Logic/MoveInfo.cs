using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.Logic
{
    class MoveInfo
    {
        public int FirstPosX { get; }
        public int FirstPosY { get; }
        public int SecondPosX { get; }
        public int SecondPosY { get; }

        public MoveInfo(int firstPosX, int firstPosY, int secondPosX, int secondPosY)
        {
            FirstPosX = firstPosX;
            FirstPosY = firstPosY;
            SecondPosX = secondPosX;
            SecondPosY = secondPosY;
        }
    }
}
