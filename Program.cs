using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fifteen.Logic;

namespace Fifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAmount = 4;
            int columnsAmount = 4;
            int windowWidth = 800;
            int windowHeight = 800;
            string imageName = "picture.jpg";

            IView view = new FormView(rowsAmount, columnsAmount, windowWidth, windowHeight, imageName);
            //IView view = new ConsoleView(rowsAmount, columnsAmount);

            GameLogic logic = new GameLogic(rowsAmount, columnsAmount);

            Controller controller = new Controller();
            controller.Run(logic, view);
        }
    }
}
