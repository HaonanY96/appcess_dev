using appcess_dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Data
{
    public class RecentAppBroker : BaseBroker<RecentApp>
    {
        public RecentAppBroker(DatabaseService databaseService) : base(databaseService)
        {
        }

        protected override Dictionary<string, string> GetPropertyToColumnMap()
        {
            return new Dictionary<string, string>
            {
                { "RecentAppId", "recent_app_id" },
                { "AppId", "app_id" },
                { "LastUsedTime", "last_used_time" }
            };
        }

        protected override string GetTableName()
        {
            return "ac_recent_app";
        }

        public List<AppEntity> GetRecentlyUsedApps(int count)
        {

        }
    }
}
