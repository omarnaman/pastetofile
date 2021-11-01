using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace PasteToFile
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    Console.WriteLine("No path passed");
                    return;
                }
                string FolderPath = args[0];
                if (Clipboard.ContainsImage())
                {
                    Console.WriteLine("Image");
                    SaveImage(FolderPath);
                }
                else if (Clipboard.ContainsText())
                {
                    Console.WriteLine("Text");
                    SaveText(FolderPath);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static void SaveText(string path)
        {
            var now = DateTime.Now;
            string fileName = $"P2F_{now.Year}{now.Month}{now.Day}-{now.Hour}{now.Minute}{now.Second}.txt";
            string filePath = Path.Combine(path, fileName);
            string clipboardText = Clipboard.GetText();
            File.WriteAllText(filePath, clipboardText);
        }
        private static void SaveImage(string path)
        {
            var now = DateTime.Now;
            string fileName = $"P2F_{now.Year}{now.Month}{now.Day}-{now.Hour}{now.Minute}{now.Second}.jpg";
            string filePath = Path.Combine(path, fileName);
            var clipboardText = Clipboard.GetImage();
            clipboardText.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

    }
}
