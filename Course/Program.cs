using System;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Course
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string fileRoute = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Ventas.xlsx"
            );
            if (IsFileBlocked(fileRoute))
            {
                MessageBox.Show("El archivo está en uso por otro programa (como Excel). Ciérralo antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ExcelPackage.License.SetNonCommercialPersonal("jeremiasbots");
            Application.Run(new Form1());
        }

        private static bool IsFileBlocked(string path)
        {
            try
            {
                using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }
    }
}
