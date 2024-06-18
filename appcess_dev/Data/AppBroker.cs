using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;

namespace appcess_dev.Data
{
    public class AppBroker : BaseBroker<App>
    {
        public AppBroker(DatabaseService databaseService) : base(databaseService)
        {
        }

        protected override Dictionary<string, string> GetPropertyToColumnMap()
        {
            return new Dictionary<string, string>
            {
                { "AppId", "app_id" },
                { "AppName", "app_name" },
                { "AppPath", "app_path" },
                { "IconData", "icon_data" },
                { "Type", "type" },
                { "CpuUsage", "cpu_usage" },
                { "MemoryUsage", "memory_usage" },
                { "DiskUsage", "disk_usage" },
                { "ThreadCount", "thread_count" },
                { "RunCount", "run_count" }
            };
        }

        protected override string GetTableName()
        {
            return "ac_app";
        }
    }
}
