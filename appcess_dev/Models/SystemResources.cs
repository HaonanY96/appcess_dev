using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class SystemResources
    {
        public float CpuAvailable { get; set; }
        public int MemoryAvailable { get; set; }
        public int StorageAvailable { get; set; }
        public int ThreadAvailable { get; set; }

        public SystemResources()
        {
            CpuAvailable = 0;
            MemoryAvailable = 0;
            StorageAvailable = 0;
            ThreadAvailable = 0;
        }

        public SystemResources(float cpuAvailable, int memoryAvailable, int storageAvailable, int threadAvailable)
        {
            if (cpuAvailable < 0 || memoryAvailable < 0 || storageAvailable < 0 || threadAvailable < 0)
            {
                throw new ArgumentOutOfRangeException("Resource values cannot be negative");
            }

            CpuAvailable = cpuAvailable;
            MemoryAvailable = memoryAvailable;
            StorageAvailable = storageAvailable;
            ThreadAvailable = threadAvailable;
        }
    }
}
