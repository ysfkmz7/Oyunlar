using System;

namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.mesaj = new System.Windows.Forms.Label();
            this.kalanhakform = new System.Windows.Forms.Label();
            this.tahmintxt = new System.Windows.Forms.TextBox();
            this.tahminbutonu = new System.Windows.Forms.Button();
            this.maskelisehir = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.mesaj.AutoSize = true;
            this.mesaj.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mesaj.Location = new System.Drawing.Point(78, 395);
            this.mesaj.Name = "lblMessage";
            this.mesaj.Size = new System.Drawing.Size(0, 36);
            this.mesaj.TabIndex = 0;
            // 
            // lblRemainingAttempts
            // 
            this.kalanhakform.AutoSize = true;
            this.kalanhakform.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kalanhakform.Location = new System.Drawing.Point(74, 179);
            this.kalanhakform.Name = "lblRemainingAttempts";
            this.kalanhakform.Size = new System.Drawing.Size(178, 32);
            this.kalanhakform.TabIndex = 1;
            this.kalanhakform.Text = "Kalan Hak: 6";
            // 
            // txtGuess
            // 
            this.tahmintxt.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tahmintxt.Location = new System.Drawing.Point(80, 118);
            this.tahmintxt.MaxLength = 1;
            this.tahmintxt.Name = "txtGuess";
            this.tahmintxt.Size = new System.Drawing.Size(100, 40);
            this.tahmintxt.TabIndex = 2;
            this.tahmintxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnGuess
            // 
            this.tahminbutonu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tahminbutonu.Location = new System.Drawing.Point(80, 255);
            this.tahminbutonu.Name = "btnGuess";
            this.tahminbutonu.Size = new System.Drawing.Size(177, 47);
            this.tahminbutonu.TabIndex = 3;
            this.tahminbutonu.Text = "Tahmin Et";
            this.tahminbutonu.UseVisualStyleBackColor = true;
            // 
            // lblMaskedCity
            // 
            this.maskelisehir.AutoSize = true;
            this.maskelisehir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskelisehir.Location = new System.Drawing.Point(74, 47);
            this.maskelisehir.Name = "lblMaskedCity";
            this.maskelisehir.Size = new System.Drawing.Size(0, 32);
            this.maskelisehir.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp3.Properties.Resources.hangman0;
            this.pictureBox1.Location = new System.Drawing.Point(602, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(907, 515);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.maskelisehir);
            this.Controls.Add(this.tahminbutonu);
            this.Controls.Add(this.tahmintxt);
            this.Controls.Add(this.kalanhakform);
            this.Controls.Add(this.mesaj);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.Label mesaj;
        private System.Windows.Forms.Label kalanhakform;
        private System.Windows.Forms.TextBox tahmintxt;
        private System.Windows.Forms.Button tahminbutonu;
        private System.Windows.Forms.Label maskelisehir;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

