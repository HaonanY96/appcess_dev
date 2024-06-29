using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Services
{
    public static class AppAccessTracker
    {
        private static readonly string LogFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AppCess",
            "app_access_log.txt"
        );

        public static void RecordAppAcess(string appPath)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {appPath}";
                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error recording app access: {ex.Message}");
            }
        }
    }
}
