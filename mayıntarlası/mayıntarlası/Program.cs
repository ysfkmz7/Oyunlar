using System;
using System.Windows.Forms;

namespace MayinTarlasi
{
    static class Program
    {
        // Uygulamanın başlangıç noktası
        [STAThread]
        static void Main()
        {
            // Uygulamanın görsel öğeleri kullanabilmesi için, uygulamanın tek iş parçacıklı (single-threaded) çalışması gerekmektedir.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Form1 sınıfını başlat ve uygulamayı çalıştır
            Application.Run(new Form1());
        }
    }
}
