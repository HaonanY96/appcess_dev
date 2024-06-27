﻿using appcess_dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Data
{
    public class AppSetBroker : BaseBroker<AppEntity>
    {
        public AppSetBroker(DatabaseService databaseService) : base(databaseService)
        {
        }

        protected override Dictionary<string, string> GetPropertyToColumnMap()
        {
            return new Dictionary<string, string>
            {
                { "AppSetId", "appset_id" },
                { "AppSetName", "appset_name" },
                { "KeyCombination", "key_combination" },
                { "AppCount", "app_count" },
                { "FileCount", "file_count" },
                { "LaunchCount", "launch_count" }
            };
        }

        protected override string GetTableName()
        {
            return "ac_appset";
        }
    }
}
