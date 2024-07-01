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
        public int AppId { get; set; }
        public byte[] ThumbnailData { get; set; }
        public int FileOpenCount { get; set; }
        public DateTime? LastAccessTime { get; set; }
        public AppEntity AssociatedApp { get; set; }


        public FileEntity() 
        {
            ThumbnailData = null;
            FileOpenCount = 0;
            LastAccessTime = null;
            AssociatedApp = null;

        }

        public FileEntity(string name, 
                          string path, 
                          int appId,
                          byte[] thumbnailData, 
                          int fileOpenCount,
                          DateTime? lastAccessTime = null,
                          AppEntity associatedApp = null)

        {
            Name = name;
            Path = path;
            AppId = appId;
            ThumbnailData = thumbnailData;
            FileOpenCount = fileOpenCount;
            LastAccessTime = lastAccessTime ?? DateTime.Now;
            AssociatedApp = associatedApp;
        }

    }
}
