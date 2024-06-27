using appcess_dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Data
{
    public class RecentFileBroker : BaseBroker<RecentFile>
    {
        public RecentFileBroker(DatabaseService databaseService) : base(databaseService)
        {
        }

        protected override Dictionary<string, string> GetPropertyToColumnMap()
        {
            return new Dictionary<string, string>
            {
                { "RecentFileId", "recent_file_id" },
                { "FileId", "file_id" },
                { "LastOpenedTime", "last_opened_time" }
            };
        }

        protected override string GetTableName()
        {
            return "ac_recent_file";
        }
    }
}
