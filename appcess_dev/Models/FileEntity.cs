using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace appcess_dev.Models
{
    public class FileEntity
    {
        public int? FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] ThumbnailData { get; set; }
        public int FileOpenCount { get; set; }
        public AppEntity AssociatedApp { get; set; }
        public DateTime? LastOpenedTime { get; set; }

        public FileEntity() 
        {
            ThumbnailData = null;
            FileOpenCount = 0;
            AssociatedApp = null;
            LastOpenedTime = null;
        }

        public FileEntity(string fileName, string filePath, byte[] thumbnailData, 
                          int fileOpenCount, AppEntity associatedApp,
                          DateTime? lastOpenedTime = null)
        {
            FileName = fileName;
            FilePath = filePath;
            ThumbnailData = thumbnailData;
            FileOpenCount = fileOpenCount;
            AssociatedApp = associatedApp;
            LastOpenedTime = lastOpenedTime;
        }

    }
}
