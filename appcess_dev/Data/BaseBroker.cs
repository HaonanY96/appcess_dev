using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;


namespace appcess_dev.Data
{
    public class BaseBroker<T> where T : class, new()
    {
        protected DatabaseService _databaseService;

        public BaseBroker(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        protected virtual Dictionary<string, string> GetPropertyToColumnMap()
        {
            throw new NotImplementedException("You must override GetPropertyToColumnMap in derived classes");
        }

        protected virtual string GetTableName()
        {
            throw new NotImplementedException("You must override GetTableName in derived classes");
        }

        public virtual void Create(T item)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propertyToColumnMap = GetPropertyToColumnMap();

            var columns = string.Join(", ", properties.Select(p => propertyToColumnMap[p.Name]));
            var values = string.Join(", ", properties.Select(p => "@" + propertyToColumnMap[p.Name]));
            var tableName = GetTableName();
            var sql = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            var parameters = properties.Select(p => new SQLiteParameter("@" + propertyToColumnMap[p.Name], p.GetValue(item) ?? DBNull.Value)).ToArray();
            _databaseService.ExecuteNonQuery(sql, parameters);
        }
    }
}
