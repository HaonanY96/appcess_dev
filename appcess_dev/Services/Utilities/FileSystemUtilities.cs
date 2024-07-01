using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using appcess_dev.Services.Interfaces;
using NLog;

namespace appcess_dev.Services.Utilities
{
    public class FileSystemUtilities
    {
        private readonly IErrorHandler _errorHandler;
        private readonly ILogger _logger;
        public FileSystemUtilities(IErrorHandler errorHandler, ILogger logger)
        {
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<byte[]> GetThumbnailAsync(string filePath, int width, int height)
        {
            try
            {
                using (var image = await Task.Run(() => Image.FromFile(filePath)))
                using (var thumbnail = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero))
                using (var memoryStream = new MemoryStream())
                {
                    await Task.Run(() => thumbnail.Save(memoryStream, ImageFormat.Png));
                    _logger.Info($"Successfully created thumbnail for {filePath}.");
                    return memoryStream.ToArray();
                }
            }
            catch (OutOfMemoryException ex)
            {
                string errorMessage = $"The file at {filePath} is not a valid image or is not supported.";
                _logger.Error(ex, errorMessage);
                _errorHandler.ShowErrorMessage(errorMessage);
                return null;
            }
            catch (Exception ex)
            {
                string errorMessage = $"An error occurred while processing the file at {filePath}.";
                _logger.Error(ex, errorMessage);
                _errorHandler.ShowErrorMessage(errorMessage);
                return null;
            }
        }
        public DateTime GetFileLastAccessTime(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                string errorMessage = $"The file at {filePath} does not exist.";
                _logger.Error(errorMessage);
                _errorHandler.ShowErrorMessage(errorMessage);
                throw new FileNotFoundException(errorMessage, filePath);
            }

            try
            {
                return File.GetLastAccessTime(filePath);
            }
            catch (Exception ex)
            {
                if (!(ex is FileNotFoundException))
                {
                    string errorMessage = $"An error occurred while accessing the file: {filePath}";
                    _logger.Error(ex, errorMessage);
                    _errorHandler.ShowErrorMessage($"{errorMessage}: {ex.Message}");
                }
                throw;
            }
        }
    }
}
