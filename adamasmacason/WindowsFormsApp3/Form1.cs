using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        // Şehir isimlerini içeren bir liste oluşturuyoruz.
        private List<string> sehirler = new List<string>
        {
            "İstanbul", "Ankara", "İzmir", "Bursa", "Adana", "Gaziantep",
            "Konya", "Antalya", "Kayseri", "Mersin", "Sakarya", "Trabzon",
            "Aydın", "Kocaeli", "Edirne", "Malatya", "Manisa", "Hatay",
            "Diyarbakır", "Elazığ", "Eskişehir", "Sivas", "Çorum", "Rize",
            "Zonguldak", "Kastamonu", "Nevşehir", "Uşak", "Niğde", "Bolu",
            "Ordu", "Tekirdağ", "Aksaray", "Karabük", "Düzce", "Batman",
            "Şırnak", "Isparta", "Bartın", "Bayburt", "Bingöl", "Bitlis",
            "Gümüşhane", "Kars", "Kırklareli", "Kırıkkale", "Osmaniye",
            "Artvin", "Amasya", "Giresun", "Sinop", "Yozgat", "Kahramanmaraş",
            "Tunceli", "Adıyaman", "Çankırı", "Karaman", "Mardin", "Muğla"
        };

        // Seçilen şehir, gizli olan şehir, kalan tahmin hakkı ve tahmin edilen harfler
        private string secilensehir;
        private string maskesehir;
        private int kalanhak;
        private HashSet<char> guessedLetters;

        // Adam asmaca resimlerini tutacak dizi
        private Image[] hangmanImages;

        public Form1()
        {
            InitializeComponent();
            LoadHangmanImages();  // Adam asmaca resimlerini yükle
            oyunbasla();        // Yeni bir oyun başlat

            // Butonun rengini ve tıklama olayını ayarlıyoruz
            tahminbutonu.BackColor = Color.BlueViolet;
            tahminbutonu.Click += new EventHandler(btnGuess_Click);
        }

        // Adam asmaca resimlerini yükleme fonksiyonu
        private void LoadHangmanImages()
        {
            try
            {
                // Resimlerin dosyalardan yüklenmesi
                hangmanImages = new Image[]
                {
                    Properties.Resources.hangman0,
                    Properties.Resources.hangman1,
                    Properties.Resources.hangman2,
                    Properties.Resources.hangman3,
                    Properties.Resources.hangman4,
                    Properties.Resources.hangman5,
                    Properties.Resources.hangman6
                };
            }
            catch (Exception ex)
            {
                // Resimler yüklenirken bir hata olursa kullanıcıya gösteriliyor
                MessageBox.Show("Resimler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        // Yeni bir oyun başlatma fonksiyonu
        private void oyunbasla()
        {
            // Rastgele bir şehir seçiyoruz
            Random random = new Random();
            secilensehir = sehirler[random.Next(sehirler.Count)].ToUpper();

            // Seçilen şehrin her harfini "_" olarak maskeliyoruz
            maskesehir = new string('_', secilensehir.Length);

            // Kalan tahmin hakkı 6 olarak başlıyor
            kalanhak = 6;

            // Tahmin edilen harfleri tutacak set
            guessedLetters = new HashSet<char>();

            // İlk resim olan adam asmaca başlatılıyor
            pictureBox1.Image = hangmanImages[0];

            // Ekran üzerindeki bilgileri güncelliyoruz
            güncelle();
        }

        // Ekrandaki bilgileri güncelleyen fonksiyon
        private void güncelle()
        {
            // gizli olan şehri ve kalan hakları gösteriyoruz
            maskelisehir.Text = string.Join(" ", maskesehir.ToCharArray());
            kalanhakform.Text = $"Kalan Hak: {kalanhak}";  // String  kullanılarak doğru yazım
            mesaj.Text = "";
            tahmintxt.Clear();   // Tahmin giriş alanını temizliyoruz
            tahmintxt.Focus();   // Kullanıcıdan yeni tahmin bekliyoruz

            // Adam asmaca resmini kalan hakka göre değiştiriyoruz
            pictureBox1.Image = hangmanImages[6 - kalanhak];

            // Eğer tahmin hakkı kalmadıysa oyun bitmiş demektir
            if (kalanhak == 0)
            {
                mesaj.Text = $"Kaybettiniz! Doğru şehir: {secilensehir}";  // String ile doğru şehir gösteriliyor
                pictureBox1.Image = hangmanImages[6]; // Tam adam asmaca resmi gösteriliyor
                tahminbutonu.Enabled = false;         // Tahmin butonunu devre dışı bırakıyoruz
            }

            // Tahmin hakkı varsa buton aktif kalıyor
            tahminbutonu.Enabled = kalanhak > 0;
        }

        // Kullanıcının harf tahminini işleyen fonksiyon
        private void btnGuess_Click(object sender, EventArgs e)
        {
            // Kullanıcı bir harf girmemişse uyarı veriyoruz
            if (tahmintxt.Text.Length == 0)
            {
                mesaj.Text = "Lütfen bir harf giriniz!";
                return;
            }

            // Kullanıcının girdiği harfi büyük harfe çeviriyoruz
            char guessedChar = tahmintxt.Text.ToUpper()[0];

            // Girdiği karakter bir harf değilse uyarı veriyoruz
            if (!char.IsLetter(guessedChar))
            {
                mesaj.Text = "Lütfen geçerli bir harf giriniz!";
                return;
            }

            // Eğer aynı harfi daha önce tahmin ettiyse tekrar uyarı veriyoruz
            if (guessedLetters.Contains(guessedChar))
            {
                mesaj.Text = "Bu harfi zaten tahmin ettiniz!";
                return;
            }

            // Harfi tahmin edilen harfler listesine ekliyoruz
            guessedLetters.Add(guessedChar);

            // Harfin doğru tahmin olup olmadığını kontrol ediyoruz
            bool tahmin = false;

            // Eğer seçilen şehirde bu harf varsa, gizli olan şehri güncelliyoruz
            if (secilensehir.Contains(guessedChar))
            {
                char[] maskedArray = maskesehir.ToCharArray();
                for (int i = 0; i < secilensehir.Length; i++)
                {
                    if (secilensehir[i] == guessedChar)
                    {
                        maskedArray[i] = guessedChar;
                        tahmin = true;
                    }
                }
                maskesehir = new string(maskedArray);
                mesaj.Text = "Doğru tahmin!";
            }
            else
            {
                // Yanlış tahmin durumunda kalan tahmin hakkını azaltıyoruz
                kalanhak--;
                mesaj.Text = "Yanlış tahmin!";
            }

            // Eğer tüm harfler doğru tahmin edilirse oyunu kazandınız mesajı gösteriyoruz
            if (maskesehir.Equals(secilensehir))
            {
                mesaj.Text = $"Tebrikler! Şehri buldunuz: {secilensehir}";
                tahminbutonu.Enabled = false;  // Buton devre dışı bırakılıyor
                return;
            }

            // Eğer tahmin hakkı kalmadıysa oyunu kaybettiniz mesajı gösteriyoruz
            if (kalanhak <= 0)
            {
                mesaj.Text = $"Kaybettiniz! Doğru şehir: {secilensehir}";
                tahminbutonu.Enabled = false;  // Buton devre dışı bırakılıyor
                pictureBox1.Image = hangmanImages[6];  // Tam adam asmaca resmi gösteriliyor
            }

            // Ekranı tekrar güncelliyoruz
            güncelle();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Bu metod gerekmedikçe boş bırakılabilir.
        }
    }
}
