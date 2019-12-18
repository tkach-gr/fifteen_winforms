using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class ConsoleView : IView
    {
        int rowsAmount;
        int columnsAmount;
        int[,] nums;

        public event CoordAction InputEvent;

        public ConsoleView(int rowsAmount, int columnsAmount)
        {
            this.rowsAmount = rowsAmount;
            this.columnsAmount = columnsAmount;
            nums = new int[rowsAmount, columnsAmount];
        }

        public void InitField(IEnumerable<int> numbers)
        {
            IEnumerator<int> enumerator = numbers.GetEnumerator();

            for (int y = 0; y < rowsAmount; y++)
            {
                for (int x = 0; x < columnsAmount; x++)
                {
                    enumerator.MoveNext();
                    nums[y, x] = enumerator.Current;
                }
            }
        }
        public void ProcessWin()
        {
            Console.Clear();
            Console.WriteLine("You win!!!");
            Console.ReadKey();
            System.Environment.Exit(0);
        }
        public void SwapCells(int FirstPosX, int FirstPosY, int SecondPosX, int SecondPosY)
        {
            int temp = nums[FirstPosY, FirstPosX];
            nums[FirstPosY, FirstPosX] = nums[SecondPosY, SecondPosX];
            nums[SecondPosY, SecondPosX] = temp;
        }
        public void Run()
        {
            DrawField();
            ConsoleKey key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.W)
                    InputEvent.Invoke(0, -1);
                else if (key == ConsoleKey.A)
                    InputEvent.Invoke(-1, 0);
                else if (key == ConsoleKey.D)
                    InputEvent.Invoke(1, 0);
                else if (key == ConsoleKey.S)
                    InputEvent.Invoke(0, 1);
                else
                    continue;

                Console.Clear();
                DrawField();
            }
        }

        private void DrawField()
        {
            for (int y = 0; y < rowsAmount; y++)
            {
                for (int i = 0; i < columnsAmount; i++)
                {
                    if (nums[y, i] < 10)
                        Console.Write("    " + nums[y, i]);
                    else
                        Console.Write("   " + nums[y, i]);
                }
                Console.WriteLine('\n');
            }
        }
    }
}
