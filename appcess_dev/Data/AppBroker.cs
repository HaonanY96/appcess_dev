using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;
using appcess_dev.Models;
using NLog;
using appcess_dev.Services.Interfaces;

namespace appcess_dev.Data
{
    public class AppBroker : BaseBroker<AppEntity>
    {
        public AppBroker(DatabaseService databaseService, ILogger logger, IErrorHandler errorHandler) : base(databaseService, logger, errorHandler)
        {
        }

        protected override Dictionary<string, string> GetPropertyToColumnMap()
        {
            return new Dictionary<string, string>
            {
                { "AppId", "app_id" },
                { "Name", "app_name" },
                { "Path", "app_path" },
                { "IconData", "icon_data" },
                { "CpuUsage", "cpu_usage" },
                { "MemoryUsage", "memory_usage" },
                { "ThreadCount", "thread_count" },
                { "RunCount", "run_count" },
                { "LastAccessTime", "last_access_time" }
            };
        }

        protected override string GetTableName()
        {
            return "ac_app";
        }

        public override void Create(AppEntity app)
        {
            //Set App properties
            base.Create(app);
        }

        public override AppEntity GetById(int appId)
        {
            return base.GetById(appId);
        }

        public override void Update(AppEntity app)
        {

        }

        public override void Delete(int id)
        {

        }

        public async Task<int>

        public void IncrementRunCount(int appId)
        {
            try
            {
                var sql = "UPDATE ac_app SET run_count = run_count + 1, last_access_time = @LastAccessTime WHERE app_id = @AppId";
                var parameters = new[]
                {
                    new SQLiteParameter("@LastAccessTime", DateTime.Now),
                    new SQLiteParameter("@AppId", appId)
                };

                _databaseService.ExecuteNonQuery(sql, parameters);
                _logger.Info($"Incremented run count for AppEntity with ID {appId}");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error incrementing run count for AppEntity with ID {appId}";
                _logger.Error(ex, errorMessage);
                _errorHandler.ShowErrorMessage(errorMessage);
                throw;
            }
        }
        //GetResourcesUsage
        //
    }
}
