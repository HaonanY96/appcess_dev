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
            using (var image = await Task.Run(() => Image.FromFile(filePath)))
            using (var thumbnail = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero))
            using (var memoryStream = new MemoryStream())
            {
                await Task.Run(() => thumbnail.Save(memoryStream, ImageFormat.Png));
                return memoryStream.ToArray();
            }
        }
        public static DateTime GetLastAccessTime(string path) 
        {
        }
    }
}
