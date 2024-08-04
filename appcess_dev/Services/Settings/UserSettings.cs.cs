using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using appcess_dev.ViewModels;
using appcess_dev.Common;
using System.Linq;

namespace appcess_dev.Services.Settings
{
    public class UserSettings : ObservableObject
    {
        private static readonly string DefaultLanguage = "en-US";
        private static readonly string[] ValidLanguages = { "en-US", "es-ES", "fr-FR" };

        private bool _darkMode;
        private string _language;
        private bool _enableFileTracking;
        private bool _enableAppTracking;
        private string _databaseBackupPath;


        public bool DarkMode
        {
            get => _darkMode;
            set => SetProperty(ref _darkMode, value);
        }

        public string Language
        {
            get => _language;
            set
            {
                if (!ValidLanguages.Contains(value))
                    throw new ArgumentException("Invalid language code");
                SetProperty(ref _language, value);
            }
        }          

        public bool EnableFileTracking
        {
            get => _enableFileTracking;
            set => SetProperty(ref _enableFileTracking, value);
        }

        public bool EnableAppTracking
        {
            get => _enableAppTracking;
            set => SetProperty(ref _enableAppTracking, value);
        }

        public string DatabaseBackupPath
        {
            get => _databaseBackupPath;
            set => SetProperty(ref _databaseBackupPath, value);
        }

        public UserSettings()
        {
            DarkMode = false;
            Language = DefaultLanguage;
            EnableFileTracking = true;
            EnableAppTracking = true;
            DatabaseBackupPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "AppCess", 
                "Backups"
            );
        }
    }
}
