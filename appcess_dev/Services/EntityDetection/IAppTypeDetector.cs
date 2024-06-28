using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Services.EntityDetection
{
    public interface IAppTypeDetector
    {
        bool IsApplication(string path);
        string GetAppType(string path);
    }
}
