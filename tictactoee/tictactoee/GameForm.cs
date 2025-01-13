using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameForm : Form
    {
        private int boardSize; // Tahta boyutu (3x3, 5x5, 7x7)
        private Button[,] buttons;
        private string[,] boardState;
        private bool isXTurn;

        // GameForm yapıcısı
        public GameForm(int size)
        {
            boardSize = size;
            isXTurn = true; // X ile başla
            boardState = new string[boardSize, boardSize];
            
            InitializeBoard();
        }

        // Tahtayı başlat
        private void InitializeBoard()
        {
            buttons = new Button[boardSize, boardSize];
            this.ClientSize = new System.Drawing.Size(50 * boardSize, 50 * boardSize); // Form boyutunu tahta boyutuna göre ayarla

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

                    boardState[i, j] = ""; // Başlangıçta her hücre boş
                }
            }
        }

        // Butona tıklama olayını yakala
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

        // Kazanan olup olmadığını kontrol et
        private bool CheckForWinner()
        {
            int winningCount = boardSize == 3 ? 3 : 4; // 3x3 için 3, 5x5 ve 7x7 için 4

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    string player = boardState[i, j];
                    if (player == "") continue;

                    // Satırda kazanan kontrolü
                    if (j <= boardSize - winningCount && CheckLine(player, winningCount, i, j, 0, 1)) return true;

                    // Sütunda kazanan kontrolü
                    if (i <= boardSize - winningCount && CheckLine(player, winningCount, i, j, 1, 0)) return true;

                    // Sağ çapraz (sol üstten sağ alta) kazanan kontrolü
                    if (i <= boardSize - winningCount && j <= boardSize - winningCount && CheckLine(player, winningCount, i, j, 1, 1)) return true;

                    // Sol çapraz (sağ üstten sol alta) kazanan kontrolü
                    if (i <= boardSize - winningCount && j >= winningCount - 1 && CheckLine(player, winningCount, i, j, 1, -1)) return true;
                }
            }

            return false;
        }

        // Kazanan olup olmadığını kontrol etmek için bir çizgiyi kontrol et
        private bool CheckLine(string player, int count, int startX, int startY, int deltaX, int deltaY)
        {
            for (int k = 0; k < count; k++)
            {
                if (boardState[startX + k * deltaX, startY + k * deltaY] != player)
                    return false;
            }
            return true;
        }

        // Tahtayı sıfırla
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
