using Microsoft.Extensions.Configuration;
using appcess_dev.Services.Settings;
using System.IO;

namespace appcess_dev.Services
{
    public class ConfigurationService
    {
        private readonly IConfiguration _configuration;
        public AppConfig AppSettings { get; private set; }

        public UserSettings UserSettings { get; private set; }

        public ConfigurationService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
            AppSettings = new AppConfig();
            _configuration.GetSection("AppSettings").Bind(AppSettings);

            UserSettings = new UserSettings();
            _configuration.GetSection("UserSettings").Bind(UserSettings);
        }

        public T GetValue<T>(string key)
        {
            return _configuration.GetValue<T>(key);
        }

        public void SaveUserSettings()
        {

        }

        public void UpdateSetting<T>(string key, T value)
        {

        }
    }
}
