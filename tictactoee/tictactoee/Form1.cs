using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn3x3_Click(object sender, EventArgs e)
        {
            GameForm3x3 gameForm = new GameForm3x3();
            gameForm.Show();
        }

        private void btn5x5_Click(object sender, EventArgs e)
        {
            GameForm5x5 gameForm = new GameForm5x5();
            gameForm.Show();
        }

        private void btn7x7_Click(object sender, EventArgs e)
        {
            GameForm7x7 gameForm = new GameForm7x7();
            gameForm.Show();
        }
    }
}
