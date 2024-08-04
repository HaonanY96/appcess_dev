using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Services.Settings
{
    public class AppConfig
    {
        public string DatabasePath { get; set; }
        public string LogLevel { get; set; }
        public int MaxRecentItems { get; set; }
    }
}
