using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace appcess_dev.Services
{
    public class LogService
    {
        private readonly ILogger _logger;

        public LogService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void LogDebug(string message) => _logger.Debug(message);
        public void LogInfo(string message) => _logger.Info(message);
        public void LogWarn(string message) => _logger.Warn(message);
        public void LogError(string message) => _logger.Error(message);
        public void LogError(Exception ex, string message) => _logger.Error(ex, message);
    }
}
