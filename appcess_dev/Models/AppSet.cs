using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class AppSet
    {
        public int? AppSetId { get; set; }
        public string AppSetName { get; set; }
        public string KeyCombination { get; set; }
        public int AppCount { get; private set; }
        public int FileCount { get; private set; }
        public int LaunchCount { get; private set; }
        public List<AppSetApp> AppSetApps { get; private set; }
        public List<AppSetFile> AppSetFiles { get; private set; }

        public AppSet() 
        {
            KeyCombination = string.Empty;
            AppCount = 0;
            FileCount = 0;
            LaunchCount = 0;
            AppSetApps = new List<AppSetApp>();
            AppSetFiles = new List<AppSetFile>();
        }

        public AppSet(string appSetName, string keyCombination)
        {
            AppSetName = appSetName;
            KeyCombination = keyCombination;

            AppCount = 0;
            FileCount = 0;
            LaunchCount = 0;
            AppSetApps = new List<AppSetApp>();
            AppSetFiles = new List<AppSetFile>();
        }

        public void AddApp(AppSetApp appSetApp)
        {
            if (appSetApp != null)
            {
                AppSetApps.Add(appSetApp);
                AppCount = AppSetApps.Count; 
            }
        }

        public void AddFile(AppSetFile appSetFile)
        {
            if (appSetFile != null)
            {
                AppSetFiles.Add(appSetFile);
                FileCount = AppSetFiles.Count;
            }
        }

        public void IncrementLaunchCount()
        {
            LaunchCount++;
        }
    }
}
