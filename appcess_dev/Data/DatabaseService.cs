using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using System.Data;

namespace appcess_dev.Data
{
    public class DatabaseService
    {
        private readonly string _databasePath;
        private SQLiteConnection _connection;

        public DatabaseService()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appDirectory = Path.Combine(localAppData, "AppCess");
            string dataDirectory = Path.Combine(appDirectory, "Data");

            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            _databasePath = Path.Combine(dataDirectory, "appsets.db3");
        }

        private async Task InitializeDatabaseAsync()
        {
            if (!File.Exists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);
                await InitializeTablesAsync();
            }
        }

        public async Task<SQLiteConnection> GetConnectionAsync()
        {
            if (_connection == null)
            {
                await InitializeDatabaseAsync();
                _connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;");
            }

            if (_connection.State == ConnectionState.Closed)
            {
                await _connection.OpenAsync();
            }

            return _connection;
        }

        public async Task ExecuteNonQueryAsync(string sql, SQLiteParameter[] parameters = null)
        {
            using (var connection = await GetConnectionAsync())
            {
                using (var command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<SQLiteDataReader> ExecuteQueryAsync(string sql, SQLiteParameter[] parameters = null)
        {
            var connection = await GetConnectionAsync();
            var command = new SQLiteCommand(sql, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return (SQLiteDataReader)await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }

        private async Task InitializeTablesAsync()
        {
            try
            {
                var connection = await GetConnectionAsync();

                string sqlApp = "CREATE TABLE IF NOT EXISTS ac_app (" +
                    "app_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "app_name TEXT NOT NULL, " +
                    "app_path TEXT NOT NULL, " +
                    "icon_data BLOB, " +
                    "cpu_usage REAL, " +
                    "memory_usage INTEGER, " +
                    "thread_count INTEGER, " +
                    "run_count INTEGER DEFAULT 0), " +
                    "last_access_time DATETIME, ";
                string sqlFile = "CREATE TABLE IF NOT EXISTS ac_file (" +
                    "file_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "file_name TEXT NOT NULL, " +
                    "file_path TEXT NOT NULL, " +
                    "app_id INTEGER, " +
                    "thumbnail_data BLOB, " +
                    "file_open_count INTEGER DEFAULT 0, " +
                    "last_access_time DATETIME, " +
                    "FOREIGN KEY (app_id) REFERENCES ac_app(app_id) ON DELETE CASCADE)";
                string sqlRecentFile = "CREATE TABLE IF NOT EXISTS ac_recent_file (" +
                    "recent_file_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "file_id INTEGER, " +
                    "last_access_time DATETIME, " +
                    "FOREIGN KEY (file_id) REFERENCES ac_file (file_id))";
                string sqlRecentApp = "CREATE TABLE IF NOT EXISTS ac_recent_app (" +
                    "recent_app_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "app_id INTEGER, " +
                    "last_access_time DATETIME, " +
                    "FOREIGN KEY (app_id) REFERENCES ac_app (app_id)";
                string sqlAppSet = "CREATE TABLE IF NOT EXISTS ac_appset (" +
                    "appset_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "appset_name TEXT NOT NULL, " +
                    "key_combination TEXT" +
                    "app_count INTEGER DEFAULT 0, " +
                    "file_count INTEGER DEFAULT 0, " +
                    "launch_count INTEGER DEFAULT 0)";
                string sqlAppSetApp = "CREATE TABLE IF NOT EXISTS ac_appset_app (" +
                    "appset_id INTEGER, " +
                    "app_id INTEGER, " +
                    "launch_order INTEGER DEFAULT 0, " +
                    "PRIMARY KEY (appset_id, app_id), " +
                    "FOREIGN KEY (appset_id) REFERENCES ac_appset(appset_id) ON DELETE CASCADE, " +
                    "FOREIGN KEY (app_id) REFERENCES ac_app(app_id) ON DELETE CASCADE)";

                using (var createTableApp = new SQLiteCommand(sqlApp, connection))
                using (var createTableFile = new SQLiteCommand(sqlFile, connection))
                using (var createTableRecentFile = new SQLiteCommand(sqlRecentFile, connection))
                using (var createTableRecentApp = new SQLiteCommand(sqlRecentApp, connection))
                using (var createTableAppSet = new SQLiteCommand(sqlAppSet, connection))
                using (var createTableAppSetApp = new SQLiteCommand(sqlAppSetApp, connection))
                {
                    await createTableApp.ExecuteNonQueryAsync();
                    await createTableFile.ExecuteNonQueryAsync();
                    await createTableRecentFile.ExecuteNonQueryAsync();
                    await createTableRecentApp.ExecuteNonQueryAsync();
                    await createTableAppSet.ExecuteNonQueryAsync();
                    await createTableAppSetApp.ExecuteNonQueryAsync();
                }

                string[] indexCommands = new string[]
                {
                    "CREATE INDEX IF NOT EXISTS idx_file_id ON ac_file(file_id)",
                    "CREATE INDEX IF NOT EXISTS idx_app_id ON ac_app(app_id)",
                    "CREATE INDEX IF NOT EXISTS idx_appset_id ON ac_appset(appset_id)",
                    "CREATE INDEX IF NOT EXISTS idx_last_opened_time ON ac_recent_file(last_opened_time)",
                    "CREATE INDEX IF NOT EXISTS idx_last_used_time ON ac_recent_app(last_used_time)"
                };

                foreach (var indexCommand in indexCommands)
                {
                    using (var command = new SQLiteCommand(indexCommand, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing database: " + ex.Message, "Database Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }         
        }

        // CRUD
        //Create
        //create app
        //create file
        //create appset
        //create recent app
        //create recent file
        //create Apps(List<App> apps)
        //create Files(List<File> files)


        //Read
        //get all apps
        //get all files
        //get all appsets
        //get all recent apps
        //get all recent files
        //search recent apps by name
        //search recent files by name
        //count apps and files in an appset
        //count appsets
        //count recent apps
        //count recent files
        //get app by id
        //get file by id
        //get app in an appset by id
        //get file in an appset by id
        //get appset by id
        //get recent app by id
        //get recent file by id

        //Update
        //update app
        //update file
        //update appset
        //update recent app
        //update recent file
        //update Apps(List<App> apps)
        //update Files(List<File> files)

        //Delete
        //delete app
        //delete file
        //delete appset
        //delete recent app
        //delete recent file
        //delete all apps
        //delete all files
        //delete all appsets
        //delete all recent apps
        //delete all recent files


    }
}
