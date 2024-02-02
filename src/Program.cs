using System;

namespace SortingVisualizer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                System.Windows.Forms.Application.Run(new MainForm());
            }
            else
            {
                Console.WriteLine("This application requires Windows 6.1 or later.");
            }
        }
    }
}
