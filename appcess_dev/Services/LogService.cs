using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using appcess_dev.Services.Interfaces;

namespace appcess_dev.Services
{
    public class LogService : ILogger
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public static void LogDebug(string message) => logger.Debug(message);
        public static void LogInfo(string message) => logger.Info(message);
        public static void LogWarn(string message) => logger.Warn(message);
        public static void LogError(string message) => logger.Error(message);
        public static void LogError(Exception ex, string message) => logger.Error(ex, message);
    }
}
