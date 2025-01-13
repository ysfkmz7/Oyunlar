using System;

namespace MayinTarlasi
{
    partial class Form1
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Temizle (Dispose) işlemi.
        /// </summary>
        /// <param name="disposing">Yönetilen kaynakları serbest bırakmak için true, diğerlerini serbest bırakmak için false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Tasarımcı desteği için gerekli metodu.
        /// Formunuzdaki tüm bileşenleri bu metod ile ekleyip çıkarabilirsiniz.
        /// Kodunuz değiştirilemez; tasarımcı tarafından sağlanan kodda değişiklik yapmaktan kaçının.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Mayın Tarlası";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        #endregion
    }
}
