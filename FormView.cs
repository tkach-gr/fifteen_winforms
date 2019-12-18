using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Fifteen
{
    class FormView : Form, IView
    {
        string imageName;

        public int RowsAmount { get; set; }
        public int ColumnsAmount { get; set; }
        public Button[,] Buttons { get; set; }

        public event CoordAction InputEvent;

        public FormView(int rowsAmount, int columnsAmount, int windowWidth, int windowHeight, string pictureName)
        {
            RowsAmount = rowsAmount;
            ColumnsAmount = columnsAmount;
            imageName = pictureName;

            int buttonWidth = windowWidth / columnsAmount;
            int buttonHeight = windowHeight / rowsAmount;

            Buttons = new Button[rowsAmount, columnsAmount];

            KeyPreview = true;
            ClientSize = new Size(columnsAmount * buttonWidth, rowsAmount * buttonHeight);
            KeyDown += FormView_KeyDown;
        }

        private void FormView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                InputEvent(0, -1);
            else if (e.KeyCode == Keys.A)
                InputEvent(-1, 0);
            else if (e.KeyCode == Keys.D)
                InputEvent(1, 0);
            else if (e.KeyCode == Keys.S)
                InputEvent(0, 1);
            else if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        public void ProcessWin()
        {
            MessageBox.Show("WIN!!");
            Application.Exit();
        }
        public void InitField(IEnumerable<int> numbers)
        {
            int buttonWidth = ClientSize.Width / ColumnsAmount;
            int buttonHeight = ClientSize.Height / RowsAmount;
            Image image = Image.FromFile(imageName);
            Size cellSize = new Size(image.Width / ColumnsAmount, image.Height / RowsAmount);
            IEnumerator<int> numbersIterator = numbers.GetEnumerator();
            Button but;
            Bitmap bm;
            Graphics gr;
            
            for (int y = 0; y < RowsAmount; y++)
            {
                for (int x = 0; x < ColumnsAmount; x++)
                {
                    numbersIterator.MoveNext();

                    but = new Button();
                    but.Size = new Size(buttonWidth, buttonHeight);
                    but.Location = new Point(x * buttonWidth, y * buttonHeight);
                    but.TextAlign = ContentAlignment.TopLeft;

                    Controls.Add(but);
                    Buttons[y, x] = but;

                    if (numbersIterator.Current == 0)
                        continue;

                    bm = new Bitmap(buttonWidth, buttonHeight);
                    gr = Graphics.FromImage(bm);
                    gr.DrawImage
                    (
                        image, 
                        new Rectangle(0, 0, buttonWidth, buttonHeight),
                        new Rectangle(
                            (numbersIterator.Current - 1) % ColumnsAmount * cellSize.Width,
                            (numbersIterator.Current - 1) / ColumnsAmount * cellSize.Height,
                            cellSize.Width, 
                            cellSize.Height),
                        GraphicsUnit.Pixel
                    );

                    but.Image = bm;
                    but.Text = (numbersIterator.Current).ToString();
                    but.Font = new Font(FontFamily.GenericSansSerif, 20);
                    but.ForeColor = Color.White;
                }
            }
        }
        public void SwapCells(int FirstPosX, int FirstPosY, int SecondPosX, int SecondPosY)
        {
            Button first = Buttons[FirstPosY, FirstPosX];
            Button second = Buttons[SecondPosY, SecondPosX];

            Point tempLocation = first.Location;
            first.Location = second.Location;
            second.Location = tempLocation;

            Buttons[FirstPosY, FirstPosX] = second;
            Buttons[SecondPosY, SecondPosX] = first;
        }
        public void Run()
        {
            Application.Run(this);
        }
    }
}
