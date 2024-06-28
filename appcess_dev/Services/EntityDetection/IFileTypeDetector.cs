using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Services.EntityDetection
{
    public interface IFileTypeDetector
    {
        bool IsFile(string path);
        string GetFileType(string path);
    }
}
