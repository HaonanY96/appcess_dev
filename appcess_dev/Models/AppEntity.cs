using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace appcess_dev.Models
{
    public class AppEntity
    {
        public int? AppId { get; set; }
        public string AppName { get; set; }
        public string AppPath { get; set; }
        public byte[] IconData { get; set; }
        public EntityTypeEnum ItemType { get; set; }

        public float CpuUsage { get; set; }
        public int MemoryUsage { get; set; }
        public int ThreadCount { get; set; }
        public int DiskUsage { get; set; }
        public int RunCount { get; set; }

        public AppEntity() 
        {
            IconData = null; 
            ItemType = EntityTypeEnum.App;
            CpuUsage = 0;
            MemoryUsage = 0;
            ThreadCount = 0;
            DiskUsage = 0;
            RunCount = 0;
        }

        public AppEntity(string appName, string appPath, byte[] iconData, EntityTypeEnum itemType, float cpuUsage, int memoryUsage, int threadCount, int diskUsage, int runCount)
        {
            AppName = appName;
            AppPath = appPath;
            IconData = iconData;
            ItemType = itemType;
            CpuUsage = cpuUsage;
            MemoryUsage = memoryUsage;
            ThreadCount = threadCount;
            DiskUsage = diskUsage;
            RunCount = runCount;
        }
    }
}
