using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class AppEntity
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public string AppPath { get; set; }
        public byte[] IconData { get; set; }
        public string Type { get; set; }
        public float CpuUsage { get; set; }
        public int MemoryUsage { get; set; }
        public int ThreadCount { get; set; }
        public int DiskUsage { get; set; }
        public int RunCount { get; set; }
    }
}
