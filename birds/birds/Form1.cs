using System;
using System.Windows.Forms;

namespace birds
{
    public partial class Form1 : Form
    {
        // Oyun değişkenleri
        int pipeSpeed = 8;        // Boruların hareket hızı
        int gravity = 15;         // Kuşun düşme hızı
        int score = 0;            // Skor
        int highScore = 0;        // En yüksek skor
        int level = 1;            // Oyun seviyesi
        bool isGameOver = false;  // Oyun bitiş durumu
        bool isGameStarted = false; // Oyun durumu
        Random randomGenerator; // Rastgele sayı üretici

        public Form1()
        {
            InitializeComponent();
            randomGenerator = new Random(); // Rastgele sayı üreticiyi başlat

            // Timer'ı ayarla ve başlat
            gameTimer.Interval = 20; // Her 20ms'de bir çalıştır
            gameTimer.Tick += new EventHandler(gameTimer_Tick); // Tick olayını bağla
            gameTimer.Start(); // Timer'ı başlat

            // Klavye olaylarını forma bağla
            this.KeyDown += new KeyEventHandler(gameKeyDown);
            this.KeyUp += new KeyEventHandler(gameKeyUp);

            // Başlangıçta boruları rastgele ayarla
            SetRandomPipePositions();

            // En yüksek skoru göster
            highScoreLabel.Text = "En Yüksek Skor: " + highScore;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Oyun bitmediyse devam et
            if (!isGameOver)
            {
                if (isGameStarted) // Oyun başladıysa
                {
                    // Kuşun düşme hareketi
                    birdPictureBox.Top += gravity;

                    // Boruların sola hareketi
                    pipeTopPictureBox.Left -= pipeSpeed;
                    pipeBottomPictureBox.Left -= pipeSpeed;

                    // Skor güncelleme
                    scoreLabel.Text = "Score: " + score;

                    // Boruların geri sarılması
                    if (pipeTopPictureBox.Left < -pipeTopPictureBox.Width)
                    {
                        SetRandomPipePositions(); // Boruları rastgele ayarla
                        pipeTopPictureBox.Left = ClientSize.Width;
                        pipeBottomPictureBox.Left = ClientSize.Width;
                        score++;

                        // Her 1s skorda bir hızı artır
                        if (score % 1 == 0) // Her 1 puanda hızı artır
                        {
                            pipeSpeed++; // Boru hızını artır
                        }
                    }

                    // Kuşun borulara veya zemine çarpma kontrolü
                    if (birdPictureBox.Bounds.IntersectsWith(pipeTopPictureBox.Bounds) ||
                        birdPictureBox.Bounds.IntersectsWith(pipeBottomPictureBox.Bounds) ||
                        birdPictureBox.Top < 0 || birdPictureBox.Bottom > ClientSize.Height)
                    {
                        EndGame();
                    }
                }
            }
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            // Space tuşuna basıldığında kuşu yukarı hareket ettir
            if (e.KeyCode == Keys.Space)
            {
                if (!isGameStarted) // Oyun başlamadıysa
                {
                    isGameStarted = true; // Oyunu başlat
                }
                if (isGameOver)
                {
                    // Oyun bittiğinde yeniden başlat
                    ResetGame();
                }
                else
                {
                    gravity = -17; // Zıplama kuvveti
                }
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            // Space tuşu bırakıldığında yerçekimi normale döner
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5; // Normal yerçekimi
            }
        }

        private void EndGame()
        {
            isGameOver = true; // Oyun bitiyor
            gameTimer.Stop(); // Timer'ı durdur

            // Oyun bittiğinde en yüksek skoru güncelle
            if (score > highScore)
            {
                highScore = score;
                highScoreLabel.Text = "En Yüksek Skor: " + highScore; // En yüksek skoru güncelle
            }

            // Oyun bittiğinde mesaj kutusu göster
            MessageBox.Show("Kaybettiniz! Puanınız: " + score, "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetGame()
        {
            // Oyun değişkenlerini sıfırla
            isGameOver = false;
            isGameStarted = false; // Oyun sıfırlandığında başlangıç durumu
            gravity = 15; // Başlangıç yerçekimi
            score = 0; // Skoru sıfırla
            level = 1; // Seviyeyi sıfırla
            pipeSpeed = 8; // Boru hızını başlangıç değerine döndür

            // Boruların başlangıç konumunu ayarla
            pipeTopPictureBox.Left = ClientSize.Width;
            pipeBottomPictureBox.Left = ClientSize.Width;

            // Kuşun başlangıç konumunu ayarla
            birdPictureBox.Top = ClientSize.Height / 2;

            // Timer'ı başlat
            gameTimer.Start();
        }

        private void SetRandomPipePositions()
        {
            // Borular için rastgele yükseklik ayarla
            int pipeHeightTop = randomGenerator.Next(100, 300); // Üst borunun yüksekliğini rastgele seç
            pipeTopPictureBox.Height = pipeHeightTop; // Üst borunun yüksekliğini ayarla

            int pipeHeightBottom = ClientSize.Height - pipeHeightTop - 150; // Alt borunun yüksekliğini hesapla (150 piksel boşluk bırak)
            pipeBottomPictureBox.Height = pipeHeightBottom; // Alt borunun yüksekliğini ayarla

            // Alt borunun üst kenarını ayarla
            pipeBottomPictureBox.Top = pipeHeightTop + 150; // Alt borunun konumunu ayarla
        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {
            // Bu event'i kullanmıyorsan boş bırakabilirsin
        }
    }
}
