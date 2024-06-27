using appcess_dev.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class AppSetFile
    {
        public int? AppSetId { get; set; }
        public FileEntity FileInfo { get; set; }
        public int FileId => FileInfo?.FileId ?? 0;
        public int LaunchOrder { get; set; }

        public AppSetFile() 
        {
            LaunchOrder = 0;
        }

        public AppSetFile(FileEntity fileInfo, int launchOrder)
        {
            FileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo), "File information cannot be null");
            LaunchOrder = launchOrder;
        }
    }
}
