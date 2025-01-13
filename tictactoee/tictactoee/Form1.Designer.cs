namespace TicTacToe
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btn3x3;
        private System.Windows.Forms.Button btn5x5;
        private System.Windows.Forms.Button btn7x7;

        private void InitializeComponent()
        {
            this.btn3x3 = new System.Windows.Forms.Button();
            this.btn5x5 = new System.Windows.Forms.Button();
            this.btn7x7 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btn3x3
            // 
            this.btn3x3.Location = new System.Drawing.Point(50, 50);
            this.btn3x3.Name = "btn3x3";
            this.btn3x3.Size = new System.Drawing.Size(200, 50);
            this.btn3x3.TabIndex = 0;
            this.btn3x3.Text = "3x3 Tahtası";
            this.btn3x3.UseVisualStyleBackColor = true;
            this.btn3x3.Click += new System.EventHandler(this.btn3x3_Click);

            // 
            // btn5x5
            // 
            this.btn5x5.Location = new System.Drawing.Point(50, 120);
            this.btn5x5.Name = "btn5x5";
            this.btn5x5.Size = new System.Drawing.Size(200, 50);
            this.btn5x5.TabIndex = 1;
            this.btn5x5.Text = "5x5 Tahtası";
            this.btn5x5.UseVisualStyleBackColor = true;
            this.btn5x5.Click += new System.EventHandler(this.btn5x5_Click);

            // 
            // btn7x7
            // 
            this.btn7x7.Location = new System.Drawing.Point(50, 190);
            this.btn7x7.Name = "btn7x7";
            this.btn7x7.Size = new System.Drawing.Size(200, 50);
            this.btn7x7.TabIndex = 2;
            this.btn7x7.Text = "7x7 Tahtası";
            this.btn7x7.UseVisualStyleBackColor = true;
            this.btn7x7.Click += new System.EventHandler(this.btn7x7_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.btn7x7);
            this.Controls.Add(this.btn5x5);
            this.Controls.Add(this.btn3x3);
            this.Name = "Form1";
            this.Text = "Tic-Tac-Toe Tahtası Seç";
            this.ResumeLayout(false);
        }
    }
}
