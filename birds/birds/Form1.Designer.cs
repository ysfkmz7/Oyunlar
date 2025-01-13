namespace birds
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
            this.components = new System.ComponentModel.Container();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.birdPictureBox = new System.Windows.Forms.PictureBox();
            this.pipeTopPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pipeBottomPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.birdPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeTopPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottomPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(243, 49);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 20);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Click += new System.EventHandler(this.scoreLabel_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Location = new System.Drawing.Point(26, 27);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(51, 20);
            this.highScoreLabel.TabIndex = 4;
            this.highScoreLabel.Text = "label1";
            // 
            // birdPictureBox
            // 
            this.birdPictureBox.Image = global::birds.Properties.Resources.bird;
            this.birdPictureBox.Location = new System.Drawing.Point(49, 185);
            this.birdPictureBox.Name = "birdPictureBox";
            this.birdPictureBox.Size = new System.Drawing.Size(28, 28);
            this.birdPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.birdPictureBox.TabIndex = 2;
            this.birdPictureBox.TabStop = false;
            // 
            // pipeTopPictureBox
            // 
            this.pipeTopPictureBox.Image = global::birds.Properties.Resources.pipedown;
            this.pipeTopPictureBox.Location = new System.Drawing.Point(526, -2);
            this.pipeTopPictureBox.Name = "pipeTopPictureBox";
            this.pipeTopPictureBox.Size = new System.Drawing.Size(58, 127);
            this.pipeTopPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeTopPictureBox.TabIndex = 0;
            this.pipeTopPictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::birds.Properties.Resources.ground;
            this.pictureBox1.Location = new System.Drawing.Point(3, 450);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pipeBottomPictureBox
            // 
            this.pipeBottomPictureBox.Image = global::birds.Properties.Resources.pipe;
            this.pipeBottomPictureBox.Location = new System.Drawing.Point(526, 355);
            this.pipeBottomPictureBox.Name = "pipeBottomPictureBox";
            this.pipeBottomPictureBox.Size = new System.Drawing.Size(58, 127);
            this.pipeBottomPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeBottomPictureBox.TabIndex = 6;
            this.pipeBottomPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(843, 478);
            this.Controls.Add(this.pipeBottomPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.birdPictureBox);
            this.Controls.Add(this.pipeTopPictureBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.birdPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeTopPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottomPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pipeTopPictureBox;
        private System.Windows.Forms.PictureBox birdPictureBox;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pipeBottomPictureBox;
    }
}

