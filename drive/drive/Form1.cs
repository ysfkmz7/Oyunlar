using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class Form1 : Form
    {
        // Oyuncu arabası, engeller ve skor için gerekli değişkenler
        private PictureBox playerCar;
        private List<PictureBox> obstacles; // Engel listesini ekliyoruz
        private Timer gameTimer;
        private int score;
        private int obstacleSpeed;
        private int level;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Form ayarları
            this.Text = "Racing Game";
            this.Size = new Size(400, 600);
            this.BackColor = Color.Gray;
            this.DoubleBuffered = true;

            // Oyuncu arabası
            playerCar = new PictureBox
            {
                Size = new Size(50, 100),
                Location = new Point(175, 400),
                Image = Image.FromFile("C:\\Users\\yusuf\\source\\repos\\drive\\drive\\Resources\\car.png"), // Oyuncu arabasını ekliyoruz
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(playerCar);

            // Engel listesi başlatılıyor
            obstacles = new List<PictureBox>();
            random = new Random();

            // Başlangıçta bir engel ekleyelim
            AddObstacles();  // Başlangıçta engel ekliyoruz

            // Zamanlayıcı
            gameTimer = new Timer
            {
                Interval = 20 // Her 20 ms'de bir çalışacak
            };
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            // Başlangıç skor, hız ve seviye
            score = 0;
            obstacleSpeed = 5;
            level = 1; // Başlangıç seviyesi

            // Klavye olayları
            this.KeyDown += Form1_KeyDown;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Engel hareketi
            foreach (var obstacle in obstacles)
            {
                obstacle.Top += obstacleSpeed; // Her engel yukarı doğru hareket eder
            }

            // Engel sıfırlama ve yeni engel ekleme
            foreach (var obstacle in obstacles)
            {
                if (obstacle.Top > this.ClientSize.Height) // Engel ekranın dışına çıktıysa
                {
                    obstacle.Top = -100;
                    // Engelin yeni konumu rastgele seçilir, ancak diğer engellerle çakışmaz
                    obstacle.Left = GetRandomXPosition(obstacle.Width);
                    score++;

                    // Her 5 puanda hız artır
                    if (score % 4 == 0)
                    {
                        obstacleSpeed++; // Engel hızını artır
                    }

                    // Her 10 puanda seviye atla ve engel sayısını artır
                   
                }
            }

            // Çarpışma kontrolü
            foreach (var obstacle in obstacles)
            {
                if (playerCar.Bounds.IntersectsWith(obstacle.Bounds)) // Eğer oyuncu arabası bir engelle çarpışırsa
                {
                    gameTimer.Stop();
                    MessageBox.Show($"Oyun Bitti! Skorunuz: {score}", "Game Over");
                    Application.Exit();
                }
            }
        }

        private void AddObstacles()
        {
            // Her seviyede maksimum 3 engel olacak şekilde rastgele engel ekliyoruz
            int obstacleCount = random.Next(1, 4); // Seviye arttıkça engel sayısı 1 ile 3 arasında olacak

            // Engel sayısını 3'e kadar artırabiliriz, engeller her seviye arttıkça daha fazla olacak
            for (int i = 0; i < obstacleCount; i++)
            {
                PictureBox newObstacle = new PictureBox
                {
                    Size = new Size(50, 100),
                    Location = new Point(GetRandomXPosition(50), -100), // Engelin yeni yatay pozisyonu belirleniyor
                    Image = Image.FromFile("C:\\Users\\yusuf\\source\\repos\\drive\\drive\\Resources\\obstacle.png"), // Engel resmini ekliyoruz
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                obstacles.Add(newObstacle); // Yeni engeli listeye ekliyoruz
                this.Controls.Add(newObstacle);
            }
        }

        // Yeni engelin yatay pozisyonu, mevcut engellerle çakışmaması için belirleniyor
        private int GetRandomXPosition(int obstacleWidth)
        {
            int newX;
            bool isOverlapping;
            do
            {
                isOverlapping = false;
                newX = random.Next(0, this.ClientSize.Width - obstacleWidth); // Yeni pozisyon belirleniyor
                // Mevcut engellerle çakışma kontrolü
                foreach (var obstacle in obstacles)
                {
                    if (newX < obstacle.Right && newX + obstacleWidth > obstacle.Left) // Çakışma varsa
                    {
                        isOverlapping = true;
                        break;
                    }
                }
            } while (isOverlapping); // Çakışma varsa yeni pozisyon denenecek
            return newX;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Oyuncu arabasını kontrol etme
            if (e.KeyCode == Keys.Left && playerCar.Left > 0)
            {
                playerCar.Left -= 10; // Sola hareket
            }
            else if (e.KeyCode == Keys.Right && playerCar.Right < this.ClientSize.Width)
            {
                playerCar.Left += 10; // Sağa hareket
            }
        }
    }
}
