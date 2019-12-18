using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Fifteen.Logic;

namespace Fifteen
{
    class Controller
    {
        GameLogic logic;
        IView view;

        public void Run(GameLogic logic, IView view)
        {
            this.logic = logic;
            this.logic.ShuffleField();

            this.view = view;
            this.view.InitField(logic.GameField);
            this.view.InputEvent += Form_InputEvent;
            this.view.Run();
        }

        private void Form_InputEvent(int xCord, int yCord)
        {
            MoveInfo moveInfo = null;

            if (xCord == 0 && yCord == -1)
                moveInfo = logic.Move(Direction.Up);
            else if (xCord == -1 && yCord == 0)
                moveInfo = logic.Move(Direction.Left);
            else if (xCord == 1 && yCord == 0)
                moveInfo = logic.Move(Direction.Right);
            else if (xCord == 0 && yCord == 1)
                moveInfo = logic.Move(Direction.Down);

            if (moveInfo == null)
                return;

            view.SwapCells(moveInfo.FirstPosX, moveInfo.FirstPosY, moveInfo.SecondPosX, moveInfo.SecondPosY);

            if (logic.IsCorrectness)
                view.ProcessWin();
        }
    }
}
