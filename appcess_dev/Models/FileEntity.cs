using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace appcess_dev.Models
{
    public class FileEntity : IEntity
    {
        public int? FileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public byte[] ThumbnailData { get; set; }
        public int FileOpenCount { get; set; }
        public AppEntity AssociatedApp { get; set; }
        public DateTime? LastAccessTime { get; set; }


        public FileEntity() 
        {
            ThumbnailData = null;
            FileOpenCount = 0;
            AssociatedApp = null;
            LastAccessTime = null;

        }

        public FileEntity(string name, 
                          string path, 
                          byte[] thumbnailData, 
                          int fileOpenCount,
                          AppEntity associatedApp = null, 
                          DateTime? lastAccessTime = null)

        {
            Name = name;
            Path = path;
            ThumbnailData = thumbnailData;
            FileOpenCount = fileOpenCount;
            AssociatedApp = associatedApp;
            LastAccessTime = lastAccessTime ?? DateTime.Now;
        }

    }
}
