using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    delegate void CoordAction(int xCord, int yCord);

    interface IView
    {
        event CoordAction InputEvent;

        void ProcessWin();
        void InitField(IEnumerable<int> numbers);
        void SwapCells(int FirstPosX, int FirstPosY, int SecondPosX, int SecondPosY);
        void Run();
    }
}
