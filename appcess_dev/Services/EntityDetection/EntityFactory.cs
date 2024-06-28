using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appcess_dev.Models;
using System.IO;

namespace appcess_dev.Services.EntityDetection
{
    public class EntityFactory
    {
        private readonly IFileTypeDetector _fileTypeDetector;
        private readonly IAppTypeDetector _appTypeDetector;

        public EntityFactory(IFileTypeDetector fileTypeDetector, IAppTypeDetector appTypeDetector)
        {
            _fileTypeDetector = fileTypeDetector;
            _appTypeDetector = appTypeDetector;
        }

        public IEntity CreateEntity(string path)
        {
            if (_fileTypeDetector.IsFile(path))
            {
                return new FileEntity
                {
                    Path = path,
                    Name = Path.GetFileName(path),
                    ThumbnailData =
                    FileOpenCount =
                    AssociatedApp =
                    LastAccessTime = File.GetLastAccessTime(path),
                };
            }
            else if (_appTypeDetector.IsApplication(path))
            {
                return new AppEntity
                {
                    Path = path,
                    Name = Path.GetFileNameWithoutExtension(path),
                    IconData = ;
                    CpuUsage = ;
                    MemoryUsage = ;
                    ThreadCount = ;
                    DiskUsage = ;
                    RunCount = ;
                    LastAccessTime = File.GetLastAccessTime(path);
                };
            }
            throw new ArgumentException("Cannot determine entity type for the given path", nameof(path));
        }
    }
}
