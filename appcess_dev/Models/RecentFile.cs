using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class RecentFile
    {
        public int FileId { get; set; }
        public FileEntity FileInfo { get; set; }
        public DateTime LastOpenedTime { get; set; }

        public RecentFile()
        {
            LastOpenedTime = DateTime.Now;
        }

        public RecentFile(int fileId, FileEntity fileInfo, DateTime lastOpened)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException(nameof(fileInfo), "File information cannot be null");
            }

            FileId = fileId;
            FileInfo = fileInfo;
            LastOpenedTime = lastOpened;
        }
    }
}
