using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class AppSetApp
    {
        public int? AppSetId { get; set; }
        public AppEntity AppInfo { get; set; }
        public int AppId => AppInfo?.AppId ?? 0;
        public int LaunchOrder { get; set; }

        public AppSetApp()
        {
            LaunchOrder = 0;
        }

        public AppSetApp(AppEntity appInfo, int launchOrder)
        {
            AppInfo = appInfo ?? throw new ArgumentNullException(nameof(appInfo), "App information cannot be null");
            LaunchOrder = launchOrder;
        }
    }
}
