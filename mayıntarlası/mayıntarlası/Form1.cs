using System;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        // Oyun boyutları
        static int satirSayisi = 20; // 20x20 boyutunda oyun alanı
        static int sutunSayisi = 20; // 20x20 boyutunda oyun alanı
        static int mayinSayisi = 40; // Daha az mayın sayısı, alanı dengede tutmak için
        static Button[,] butonlar = new Button[satirSayisi, sutunSayisi];
        static bool[,] mayinlar = new bool[satirSayisi, sutunSayisi];
        static int[,] komsular = new int[satirSayisi, sutunSayisi]; // Etrafındaki mayın sayısını tutan dizi
        static bool[,] bayraklar = new bool[satirSayisi, sutunSayisi]; // Bayrakları tutacak dizi

        public Form1()
        {
            InitializeComponent();
            OyunAlaniOlustur();
            MayinlariYerlestir();
            KomsulariHesapla();
        }

        // Oyun alanını oluştur
        private void OyunAlaniOlustur()
        {
            // Formu ayarlama
            this.ClientSize = new System.Drawing.Size(sutunSayisi * 30, satirSayisi * 30);

            // Butonları dinamik olarak oluştur
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    Button buton = new Button();
                    buton.Size = new System.Drawing.Size(30, 30);
                    buton.Location = new System.Drawing.Point(j * 30, i * 30);
                    buton.Click += new EventHandler(Button_Click);
                    buton.MouseDown += new MouseEventHandler(Button_MouseDown); // Sağ tıklama için event ekle
                    buton.Name = $"btn_{i}_{j}";
                    buton.Text = " "; // Başlangıçta boş
                    buton.Tag = new int[] { i, j }; // Satır ve sütun bilgisini butona ekle
                    butonlar[i, j] = buton;
                    this.Controls.Add(buton);
                }
            }
        }

        // Mayınları yerleştir
        private void MayinlariYerlestir()
        {
            Random rastgele = new Random();
            int mayinlarYerlesmis = 0;

            while (mayinlarYerlesmis < mayinSayisi)
            {
                int satir = rastgele.Next(0, satirSayisi);
                int sutun = rastgele.Next(0, sutunSayisi);

                if (!mayinlar[satir, sutun]) // Eğer o hücrede mayın yoksa
                {
                    mayinlar[satir, sutun] = true; // Mayın yerleştir
                    mayinlarYerlesmis++;
                }
            }
        }

        // Komşulardaki mayın sayısını hesapla
        private void KomsulariHesapla()
        {
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (mayinlar[i, j])
                    {
                        // Eğer bu hücrede mayın varsa, komşularını güncelle
                        for (int di = -1; di <= 1; di++)
                        {
                            for (int dj = -1; dj <= 1; dj++)
                            {
                                int yeniSatir = i + di;
                                int yeniSutun = j + dj;

                                // Hücrenin oyun alanı içinde olup olmadığını kontrol et
                                if (yeniSatir >= 0 && yeniSatir < satirSayisi && yeniSutun >= 0 && yeniSutun < sutunSayisi)
                                {
                                    komsular[yeniSatir, yeniSutun]++;
                                }
                            }
                        }
                    }
                }
            }
        }

        // Butona tıklandığında yapılacak işlem
        private void Button_Click(object sender, EventArgs e)
        {
            Button tiklananButon = (Button)sender;
            int[] konum = (int[])tiklananButon.Tag;
            int satir = konum[0];
            int sutun = konum[1];

            if (mayinlar[satir, sutun])
            {
                tiklananButon.Text = "💣"; // Mayına basıldığında mayın sembolü göster
                MessageBox.Show("Mayına bastınız! Oyun bitti.");
                // Oyun bittiğinde tüm butonları devre dışı bırak
                TümButonlariDevreDışıBırak();

                // Oyun bittiğinde tekrar başlama seçeneği sun
                if (MessageBox.Show("Tekrar başlamak ister misiniz?", "Oyun Bitti", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    OyunBaslat(); // Yeni bir oyun başlat
                }
            }
            else
            {
                // Mayın yoksa, komşularındaki mayın sayısını göster
                tiklananButon.Text = komsular[satir, sutun] > 0 ? komsular[satir, sutun].ToString() : " ";

                // Eğer komşularında mayın yoksa, etrafındaki hücrelere de bak
                if (komsular[satir, sutun] == 0)
                {
                    BosHucresiniAç(satir, sutun);
                }
            }

            // Butonları devre dışı bırak
            tiklananButon.Enabled = false;

            // Oyun bitti mi kontrolü
            OyunBittiKontrol();
        }

        // Etrafındaki hücrelerde mayın olmayan hücreleri aç
        private void BosHucresiniAç(int satir, int sutun)
        {
            for (int di = -1; di <= 1; di++)
            {
                for (int dj = -1; dj <= 1; dj++)
                {
                    int yeniSatir = satir + di;
                    int yeniSutun = sutun + dj;

                    // Hücrenin oyun alanı içinde olup olmadığını kontrol et
                    if (yeniSatir >= 0 && yeniSatir < satirSayisi && yeniSutun >= 0 && yeniSutun < sutunSayisi)
                    {
                        Button komsuButon = butonlar[yeniSatir, yeniSutun];

                        // Eğer buton hâlâ aktifse ve bu hücrede mayın yoksa
                        if (komsuButon.Enabled && komsular[yeniSatir, yeniSutun] == 0)
                        {
                            komsuButon.Text = " ";
                            komsuButon.Enabled = false;
                            BosHucresiniAç(yeniSatir, yeniSutun); // Rekürsif olarak etrafı aç
                        }
                        else if (komsuButon.Enabled)
                        {
                            komsuButon.Text = komsular[yeniSatir, yeniSutun].ToString();
                            komsuButon.Enabled = false;
                        }
                    }
                }
            }
        }

        // Oyun bittiğinde tüm butonları devre dışı bırak
        private void TümButonlariDevreDışıBırak()
        {
            foreach (Button buton in butonlar)
            {
                buton.Enabled = false;
            }
        }

        // Oyun başlatma metodunu sıfırlama
        private void OyunBaslat()
        {
            // Mayınları ve komşu sayılarını sıfırlıyoruz
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (butonlar[i, j] != null)
                    {
                        butonlar[i, j].Enabled = true; // Butonları tekrar etkinleştir
                        butonlar[i, j].Text = " "; // Butonları temizle
                    }
                    mayinlar[i, j] = false; // Mayınları sıfırla
                    komsular[i, j] = 0; // Komşuları sıfırla
                    bayraklar[i, j] = false; // Bayrakları sıfırla
                }
            }
            MayinlariYerlestir(); // Yeni mayınlar yerleştir
            KomsulariHesapla(); // Komşuları tekrar hesapla
        }

        // Sağ tıklama ile bayrak yerleştirme
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button tiklananButon = (Button)sender;
                int[] konum = (int[])tiklananButon.Tag;
                int satir = konum[0];
                int sutun = konum[1];

                if (bayraklar[satir, sutun])
                {
                    // Bayrak varsa kaldır
                    tiklananButon.Text = " ";
                    bayraklar[satir, sutun] = false;
                }
                else
                {
                    // Bayrak ekle
                    tiklananButon.Text = "🚩";
                    bayraklar[satir, sutun] = true;
                }
            }
        }

        // Oyun bitti mi kontrolü
        private void OyunBittiKontrol()
        {
            int acikHucresayisi = 0;
            int dogruBayrakSayisi = 0;

            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    // Açılmamış hücre sayısını bul
                    if (butonlar[i, j].Enabled)
                    {
                        acikHucresayisi++;
                    }

                    // Doğru yerleştirilen bayrakları say
                    if (bayraklar[i, j] && mayinlar[i, j])
                    {
                        dogruBayrakSayisi++;
                    }
                }
            }

            // Eğer açılmamış hücre yoksa ve doğru bayrak sayısı mayın sayısına eşitse, oyun kazanıldı demektir
            if (acikHucresayisi == mayinSayisi && dogruBayrakSayisi == mayinSayisi)
            {
                MessageBox.Show("Kazandınız!");
                TümButonlariDevreDışıBırak();
            }
        }
    }
}
