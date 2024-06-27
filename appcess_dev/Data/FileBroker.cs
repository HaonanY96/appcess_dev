using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;
using appcess_dev.Models;

namespace appcess_dev.Data
{
    public class FileBroker : BaseBroker<FileEntity>
    {
        public FileBroker(DatabaseService databaseService) : base(databaseService)
        {
        }

        protected override Dictionary<string, string> GetPropertyToColumnMap()
        {
            return new Dictionary<string, string>
            {
                { "FileId", "file_id" },
                { "FileName", "file_name" },
                { "FilePath", "file_path" },
                { "ThumbnailData", "thumbnail" },
                { "FileOpenCount", "file_open_count" },
                { "LastOpenedTime", "last_opened_time" }
            };
        }

        protected override string GetTableName()
        {
            return "ac_file";
        }
    }
}
