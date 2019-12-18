using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.Logic
{
    class GameLogic
    {
        public Field GameField { get; set; }
        public bool IsCorrectness
        {
            get
            {
                for (int y = 0; y < GameField.RowsAmount; y++)
                {
                    for (int x = 0; x < GameField.ColumnsAmount; x++)
                    {
                        if (GameField[y, x] == 0 && y == GameField.RowsAmount - 1 && x == GameField.ColumnsAmount - 1)
                            continue;

                        if (GameField[y, x] != y * GameField.ColumnsAmount + x + 1)
                            return false;
                    }
                }
                return true;
            }
        }

        public GameLogic(int rowsAmount, int columnsAmount)
        {
            GameField = new Field(rowsAmount, columnsAmount);
            FillField();
        }

        public MoveInfo Move(Direction dir)
        {
            int xFirstPos;
            int yFirstPos;
            
            GameField.FindZeroCellPosition(out xFirstPos, out yFirstPos);

            int xSecondPos = xFirstPos;
            int ySecondPos = yFirstPos;

            if (dir == Direction.Up)
                ySecondPos -= 1;
            else if (dir == Direction.Left)
                xSecondPos -= 1;
            else if (dir == Direction.Right)
                xSecondPos += 1;
            else if (dir == Direction.Down)
                ySecondPos += 1;

            if (GameField.IsOutOfRange(xSecondPos, ySecondPos) != true)
            {
                int temp = GameField[yFirstPos, xFirstPos];
                GameField[yFirstPos, xFirstPos] = GameField[ySecondPos, xSecondPos];
                GameField[ySecondPos, xSecondPos] = temp;
                return new MoveInfo(xSecondPos, ySecondPos, xFirstPos, yFirstPos);
            }
            else
            {
                return null;
            }
        }
        public void ShuffleField()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < 2000; i++)
            {
                Move((Direction)rand.Next(5));
            }

            if (IsCorrectness == true)
                ShuffleField();
        }

        private void FillField()
        {
            for (int y = 0; y < GameField.RowsAmount; y++)
            {
                for (int i = 0; i < GameField.ColumnsAmount; i++)
                {
                    if (y == GameField.RowsAmount - 1 && i == GameField.ColumnsAmount - 1)
                        break;

                    GameField[y, i] = y * GameField.ColumnsAmount + i + 1;
                }
            }

            GameField[GameField.RowsAmount - 1, GameField.ColumnsAmount - 1] = 0;
        }
    }
}
