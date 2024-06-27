using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class RecentApp
    {
        public int? RecentAppId { get; set; }
        public AppEntity AppInfo { get; set; }
        public int AppId => AppInfo?.AppId ?? 0;
        public DateTime LastUsedTime => AppInfo.LastUsedTime ?? DateTime.MinValue;

        public RecentApp()
        {
            AppInfo = new AppEntity();
        }

        public RecentApp(AppEntity appInfo)
        {
            AppInfo = appInfo ?? throw new ArgumentNullException(nameof(appInfo), "App information cannot be null");
        }
    }
}
