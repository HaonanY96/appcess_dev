using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appcess_dev.Models;
using System.Data.SQLite;
using System.IO;

namespace appcess_dev.Services
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
            InitializeDatabase();

        }

        private void InitializeDatabase()
        {
            if (!File.Exists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);
                _connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;");
            }
        }

        private async Task InitializeAsync()
        {
            try
            {
                InitializeDatabase();

                await _connection.OpenAsync();

                string sqlApp = "CREATE TABLE IF NOT EXISTS ac_app (" +
                    "app_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "app_name TEXT NOT NULL, " +
                    "app_path TEXT NOT NULL, " +
                    "icon_data BLOB, " +
                    "type TEXT NOT NULL, " +
                    "cpu_usage REAL, " +
                    "memory_usage INTEGER, " +
                    "disk_usage INTEGER, " +
                    "thread_count INTEGER, " +
                    "run_count INTEGER DEFAULT 0)";
                string sqlFile = "CREATE TABLE IF NOT EXISTS ac_file (" +
                    "file_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "file_name TEXT NOT NULL, " +
                    "file_path TEXT NOT NULL, " +
                    "app_id INTEGER, " +
                    "thumbnail BLOB, " +
                    "file_open_count INTEGER DEFAULT 0, " +
                    "FOREIGN KEY (app_id) REFERENCES ac_app(app_id) ON DELETE CASCADE)";
                string sqlRecentFile = "CREATE TABLE IF NOT EXISTS ac_recent_file (" +
                    "recent_file_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "file_id INTEGER, " +
                    "last_opened_time DATETIME, " +
                    "FOREIGN KEY (file_id) REFERENCES ac_file (file_id))";
                string sqlRecentApp = "CREATE TABLE IF NOT EXISTS ac_recent_app (" +
                    "recent_app_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "app_id INTEGER, " +
                    "last_used_time DATETIME, " +
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

                SQLiteCommand createTableApp = new SQLiteCommand(sqlApp, _connection);
                SQLiteCommand createTableFile = new SQLiteCommand(sqlFile, _connection);
                SQLiteCommand createTableRecentFile = new SQLiteCommand(sqlRecentFile, _connection);
                SQLiteCommand createTableRecentApp = new SQLiteCommand(sqlRecentApp, _connection);
                SQLiteCommand createTableAppSet = new SQLiteCommand(sqlAppSet, _connection);
                SQLiteCommand createTableAppSetApp = new SQLiteCommand(sqlAppSetApp, _connection);
                

                await createTableApp.ExecuteNonQueryAsync();
                await createTableFile.ExecuteNonQueryAsync();
                await createTableRecentFile.ExecuteNonQueryAsync();
                await createTableRecentApp.ExecuteNonQueryAsync();
                await createTableAppSet.ExecuteNonQueryAsync();
                await createTableAppSetApp.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing database: " + ex.Message);
                throw;
            }
            finally
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
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
