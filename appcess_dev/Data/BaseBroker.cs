using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;
using appcess_dev.Services.Interfaces;
using NLog;



namespace appcess_dev.Data
{
    public abstract class BaseBroker<T> where T : class, new()
    {
        protected readonly DatabaseService _databaseService;
        protected readonly ILogger _logger;
        protected readonly IErrorHandler _errorHandler;

        protected BaseBroker(DatabaseService databaseService, ILogger logger, IErrorHandler errorHandler)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

        protected abstract Dictionary<string, string> GetPropertyToColumnMap();
        protected abstract string GetTableName();

        public virtual void Create(T item)
        {
            try
            {
                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var propertyToColumnMap = GetPropertyToColumnMap();

                var columns = string.Join(", ", properties.Select(p => propertyToColumnMap[p.Name]));
                var values = string.Join(", ", properties.Select(p => "@" + propertyToColumnMap[p.Name]));
                var tableName = GetTableName();
                var sql = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                var parameters = properties.Select(p => new SQLiteParameter("@" + propertyToColumnMap[p.Name], p.GetValue(item) ?? DBNull.Value)).ToArray();
                _databaseService.ExecuteNonQuery(sql, parameters);

                _logger.Info($"Created new {typeof(T).Name} in {tableName}");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error creating {typeof(T).Name}";
                _logger.Error(ex, errorMessage);
                _errorHandler.ShowErrorMessage(errorMessage);
                throw;
            }
        }

        public virtual T GetById(int id)
        {
            try
            {
                var tableName = GetTableName();
                var propertyToColumnMap = GetPropertyToColumnMap();
                var idColumnName = propertyToColumnMap.First(x => x.Key.ToLower().EndsWith("id")).Value;

                var sql = $"SELECT * FROM {tableName} WHERE {idColumnName} = @Id";
                var parameters = new[] { new SQLiteParameter("@Id", id) };

                using (var reader = _databaseService.ExecuteQuery(sql, parameters))
                {
                    if (reader.Read())
                    {
                        return MapReaderToEntity(reader);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error retrieving {typeof(T).Name} with ID {id}";
                _logger.Error(ex, errorMessage);
                _errorHandler.ShowErrorMessage(errorMessage);
                throw;
            }
        }

        protected virtual T MapReaderToEntity(SQLiteDataReader reader)
        {
            var entity = new T();
            var properties = typeof(T).GetProperties();
            var propertyToColumnMap = GetPropertyToColumnMap();

            foreach (var prop in properties)
            {
                if (propertyToColumnMap.TryGetValue(prop.Name, out var columnName))
                {
                    var value = reader[columnName];
                    if (value != DBNull.Value)
                    {
                        prop.SetValue(entity, Convert.ChangeType(value, prop.PropertyType));
                    }
                }
            }

            return entity;
        }

        public virtual TProperty GetPropertyById<TProperty>(int id, string propertyName)
        {
            try
            {
                var tableName = GetTableName();
                var propertyToColumnMap = GetPropertyToColumnMap();
                var idColumnName = propertyToColumnMap.First(x => x.Key.ToLower().EndsWith("id")).Value;
                
                if (!propertyToColumnMap.TryGetValue(propertyName, out var columnName))
                {
                    throw new ArgumentException($"Property {propertyName} not found in the mapping", nameof(propertyName));
                }

                var sql = $"SELECT {columnName} FROM {tableName} WHERE {idColumnName} = @Id";
                var parameters = new[] { new SQLiteParameter("@Id", id) };

                using (var reader = _databaseService.ExecuteQuery(sql, parameters))
                {
                    if (reader.Read())
                    {
                        var value = reader[columnName];
                        if (value == DBNull.Value)
                        {
                            return default(TProperty);
                        }
                        return (TProperty)Convert.ChangeType(value, typeof(TProperty));
                    }
                }

                return default(TProperty);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error retrieving property {propertyName} for {typeof(T).Name} with ID {id}";
                _logger.Error(ex, errorMessage);
                _errorHandler.ShowErrorMessage(errorMessage);
                throw;
            }
        }


    }
}
