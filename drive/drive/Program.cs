using System;
using System.Windows.Forms;

namespace RacingGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Gelişmiş görseller için
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Ana formu çalıştır
        }
    }
}
