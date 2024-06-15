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
    public class LocalDBService
    {
        // where should I put the database file?
        private string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appcessdb.db3");
        private SQLiteConnection _connection;

        public LocalDBService()
        {
            Initialize();

        }

        private void Initialize()
        {
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            _connection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
            //_connection.Open();

            string sql
        }

    }
}
