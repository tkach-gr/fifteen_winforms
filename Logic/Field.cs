using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.Logic
{
    class Field : IEnumerable<int>
    {
        readonly int[,] cells;

        public int RowsAmount { get; set; }
        public int ColumnsAmount { get; set; }

        public int this[int y, int x]
        {
            get
            {
                return cells[y, x];
            }
            set
            {
                cells[y, x] = value;
            }
        }

        public Field(int rowsAmount, int columnsAmount)
        {
            RowsAmount = rowsAmount;
            ColumnsAmount = columnsAmount;
            cells = new int[rowsAmount, columnsAmount];
        }

        public void FindZeroCellPosition(out int xPos, out int yPos)
        {
            for (int y = 0; y < RowsAmount; y++)
            {
                for (int i = 0; i < ColumnsAmount; i++)
                {
                    if (this[y, i] == 0)
                    {
                        yPos = y;
                        xPos = i;
                        return;
                    }
                }
            }

            throw new FormatException("Zero cell not found.");
        }
        public bool IsOutOfRange(int xPos, int yPos)
        {
            if (xPos < 0 || xPos >= ColumnsAmount || yPos < 0 || yPos >= RowsAmount)
                return true;
            else
                return false;
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        class Enumerator : IEnumerator<int>
        {
            Field field;
            int xIndex;
            int yIndex;

            public int Current => field[yIndex, xIndex];
            object IEnumerator.Current => field[yIndex, xIndex];

            public Enumerator(Field field)
            {
                this.field = field;
                xIndex = -1;
                yIndex = 0;
            }

            public void Dispose()
            {
                
            }
            public bool MoveNext()
            {
                if (yIndex == field.RowsAmount - 1 && xIndex == field.ColumnsAmount - 1)
                {
                    return false;
                }
                if (xIndex == field.ColumnsAmount - 1)
                {
                    xIndex = 0;
                    yIndex++;
                    return true;
                }
                else
                {
                    xIndex++;
                    return true;
                }
            }
            public void Reset()
            {
                xIndex = -1;
                yIndex = 0;
            }
        }
    }
}
