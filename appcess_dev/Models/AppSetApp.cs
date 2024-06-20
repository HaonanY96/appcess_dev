﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public class AppSetApp
    {
        public int AppSetId { get; set; }
        public int AppId { get; set; }
        public int LaunchOrder { get; set; }

        public AppSetApp()
        {
            LaunchOrder = 0;
        }

        public AppSetApp(int appSetId, int appId, int launchOrder)
        {
            AppSetId = appSetId;
            AppId = appId;
            LaunchOrder = launchOrder;
        }
    }
}
