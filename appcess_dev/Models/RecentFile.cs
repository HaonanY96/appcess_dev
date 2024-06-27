using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class RecentFile
    {
        public int? RecentFileId { get; set; }
        public FileEntity FileInfo { get; set; }
        public int FileId => FileInfo?.FileId ?? 0;
        public DateTime LastOpenedTime => FileInfo.LastOpenedTime ?? DateTime.MinValue;

        public RecentFile()
        {
            FileInfo = new FileEntity();
        }

        public RecentFile(FileEntity fileInfo)
        {
            FileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo), "File information cannot be null");
        }
    }
}
