using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application
{
    public class AppStaurtUp
    {
        
    }


    public class APISettings
    {
        public string IntegrationID { get; set; }
        public string BaseDevURL { get; set; }
        public string SelectedEnviorement { get; 
                set; }
    }

    public class AppInfo
    {
        public string ApplicaionName { get; set; }
    }

    public class AppSettings
    {
        public AppInfo AppInfo { get; set; }
        public APISettings APISettings { get; set; }
    }
}
