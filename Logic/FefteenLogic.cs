using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.Logic
{
    class FefteenLogic
    {
        public Field GameField { get; set; }

        public FefteenLogic(int xSize, int ySize)
        {
            GameField = new Field(ySize, xSize);
            FillField();
            //ShuffleField();
        }

        public void Move(Direction dir)
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
            }
        }

        private void FillField()
        {
            for (int y = 0; y < GameField.RowsAmount; y++)
            {
                for (int i = 0; i < GameField.ColumnsAmount; i++)
                {
                    GameField[y, i] = y * GameField.ColumnsAmount + i;
                }
            }
        }
        private void ShuffleField()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);


        }
        
    }
}
