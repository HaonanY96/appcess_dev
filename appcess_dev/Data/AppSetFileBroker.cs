using appcess_dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Data
{
    public class AppSetFileBroker : BaseBroker<AppSetFile>
    {
        public AppSetFileBroker(DatabaseService databaseService) : base(databaseService)
        {
        }

        protected override Dictionary<string, string> GetPropertyToColumnMap()
        {
            return new Dictionary<string, string>
            {
                { "AppSetId", "appset_id" },
                { "FileId", "file_id" },
                { "LaunchOrder", "launch_order" }
            };
        }

        protected override string GetTableName()
        {
            return "ac_appset_file";
        }
    }
}
