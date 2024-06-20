using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class RecentApp
    {
        public int AppId { get; set; }
        public AppEntity AppInfo { get; set; }
        public DateTime LastOpenedTime { get; set; }

        public RecentApp()
        {
            LastOpenedTime = DateTime.Now;
        }

        public RecentApp(int appId, AppEntity appInfo, DateTime lastOpened)
        {
            if (appInfo == null)
            {
                throw new ArgumentNullException(nameof(appInfo), "App information cannot be null");
            }

            AppId = appId;
            AppInfo = appInfo;
            LastOpenedTime = lastOpened;
        }
    }
}
