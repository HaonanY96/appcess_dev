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
        public EntityTypeEnum ItemType { get; set; }
        public int FileOpenCount { get; set; }
        public AppEntity AssociatedApp { get; set; }

        public FileEntity() 
        {
            ThumbnailData = null;
            ItemType = EntityTypeEnum.File;
            FileOpenCount = 0;
            AssociatedApp = null;
        }

        public FileEntity(string fileName, string filePath, byte[] thumbnailData, EntityTypeEnum itemType, int fileOpenCount, AppEntity associatedApp)
        {
            FileName = fileName;
            FilePath = filePath;
            ThumbnailData = thumbnailData;
            ItemType = itemType;
            FileOpenCount = fileOpenCount;
            AssociatedApp = associatedApp;
        }

    }
}
