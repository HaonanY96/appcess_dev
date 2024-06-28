using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace appcess_dev.Models
{
    public class AppEntity : IEntity
    {
        public int? AppId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public byte[] IconData { get; set; }

        public float CpuUsage { get; set; }
        public int MemoryUsage { get; set; }
        public int ThreadCount { get; set; }
        public int RunCount { get; set; }
        public DateTime? LastAccessTime { get; set; }


        public AppEntity() 
        {
            IconData = null; 
            CpuUsage = 0;
            MemoryUsage = 0;
            ThreadCount = 0;
            RunCount = 0;
            LastAccessTime = null;

        }

        public AppEntity(string name, 
                         string path, 
                         byte[] iconData, 
                         float cpuUsage,
                         int memoryUsage, 
                         int threadCount,  
                         int runCount, 
                         DateTime? lastAccessTime = null)
        {
            Name = name;
            Path = path;
            IconData = iconData;
            CpuUsage = cpuUsage;
            MemoryUsage = memoryUsage;
            ThreadCount = threadCount;
            RunCount = runCount;
            LastAccessTime = lastAccessTime ?? DateTime.Now;
        }
    }
}
