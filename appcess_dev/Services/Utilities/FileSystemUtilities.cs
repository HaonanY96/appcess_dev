using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace appcess_dev.Services.Utilities
{
    public static class FileSystemUtilities
    {
        public static async Task<byte[]> GetThumbnailAsync(string filePath, int width, int height)
        {
            try
            {
                using (var image = await Task.Run(() => Image.FromFile(filePath)))
                using (var thumbnail = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero))
                using (var memoryStream = new MemoryStream())
                {
                    await Task.Run(() => thumbnail.Save(memoryStream, ImageFormat.Png));
                    return memoryStream.ToArray();
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine($"The file at {filePath} is not a valid image or is not supported.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing the file at {filePath}: {ex.Message}");
                return null;
            }
        }
        public static DateTime GetFileLastAccessTime(string filePath) 
        {
            if (File.Exists(filePath))
            {
                return File.GetLastAccessTime(filePath);
            }
            throw new FileNotFoundException($"The file at {filePath} does not exist.");
        }
    }
}
