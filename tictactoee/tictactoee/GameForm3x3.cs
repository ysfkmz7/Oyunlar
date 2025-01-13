using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameForm3x3 : Form
    {
        private int boardSize = 3; // 3x3 tahtası
        private Button[,] buttons;
        private string[,] boardState;
        private bool isXTurn;

        public GameForm3x3()
        {
            
            isXTurn = true; // X ile başlıyor
            boardState = new string[boardSize, boardSize];
            InitializeBoard();
        }

       

        private void InitializeBoard()
        {
            buttons = new Button[boardSize, boardSize];
            this.ClientSize = new System.Drawing.Size(50 * boardSize, 50 * boardSize); // Form boyutu

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new System.Drawing.Size(50, 50);
                    buttons[i, j].Location = new System.Drawing.Point(50 * i, 50 * j);
                    buttons[i, j].Click += new EventHandler(Button_Click);
                    buttons[i, j].Tag = new System.Drawing.Point(i, j);
                    this.Controls.Add(buttons[i, j]);

                    boardState[i, j] = ""; // Başlangıçta boş
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            System.Drawing.Point point = (System.Drawing.Point)clickedButton.Tag;

            if (boardState[point.X, point.Y] == "")
            {
                if (isXTurn)
                {
                    clickedButton.Text = "X";
                    boardState[point.X, point.Y] = "X";
                }
                else
                {
                    clickedButton.Text = "O";
                    boardState[point.X, point.Y] = "O";
                }

                isXTurn = !isXTurn;

                if (CheckForWinner())
                {
                    string winner = isXTurn ? "O" : "X";
                    MessageBox.Show(winner + " kazandı!", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetBoard();
                }
            }
        }

        private bool CheckForWinner()
        {
            // Satır ve sütun kontrolü
            for (int i = 0; i < boardSize; i++)
            {
                if (CheckLine(boardState[i, 0], boardState[i, 1], boardState[i, 2])) return true;
                if (CheckLine(boardState[0, i], boardState[1, i], boardState[2, i])) return true;
            }

            // Çapraz kontrolü
            if (CheckLine(boardState[0, 0], boardState[1, 1], boardState[2, 2])) return true;
            if (CheckLine(boardState[0, 2], boardState[1, 1], boardState[2, 0])) return true;

            return false;
        }

        private bool CheckLine(string a, string b, string c)
        {
            return a != "" && a == b && a == c;
        }

        private void ResetBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    buttons[i, j].Text = "";
                    boardState[i, j] = "";
                }
            }
            isXTurn = true;
        }
    }
}
