using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameForm5x5 : Form
    {
        private int boardSize = 5; // 5x5 tahtası
        private Button[,] buttons;
        private string[,] boardState;
        private bool isXTurn;

        public GameForm5x5()
        {
            //InitializeComponent(); // istemediğiniz için kaldırdım
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
                for (int j = 0; j < boardSize; j++)
                {
                    if (i <= boardSize - 3 && CheckLine(boardState[i, j], boardState[i + 1, j], boardState[i + 2, j])) return true;
                    if (j <= boardSize - 3 && CheckLine(boardState[i, j], boardState[i, j + 1], boardState[i, j + 2])) return true;
                }
            }

            // Çapraz kontrolü
            for (int i = 0; i <= boardSize - 3; i++) // Çaprazlar için döngü
            {
                // Sol üstten sağ alta çapraz
                if (CheckLine(boardState[i, i], boardState[i + 1, i + 1], boardState[i + 2, i + 2])) return true;

                // Sağ üstten sol alta çapraz
                if (CheckLine(boardState[i, boardSize - 1 - i], boardState[i + 1, boardSize - 2 - i], boardState[i + 2, boardSize - 3 - i])) return true;
            }

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
