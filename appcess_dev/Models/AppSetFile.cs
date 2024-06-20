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
        public int AppSetId { get; set; }
        public int FileId { get; set; }
        public int LaunchOrder { get; set; }

        public AppSetFile() 
        {
            LaunchOrder = 0;
        }

        public AppSetFile(int appSetId, int fileId, int launchOrder)
        {
            AppSetId = appSetId;
            FileId = fileId;
            LaunchOrder = launchOrder;
        }
    }
}
