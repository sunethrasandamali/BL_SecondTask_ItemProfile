using BlueLotus360.Data.APIConsumer.APIConsumer.RestAPIConsumer;
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
        private readonly AppSettings _appSettings;

        public AppStaurtUp()
        {
            _appSettings=new AppSettings();
            RestsharpAPIConsumer.Initilize(_appSettings.APISettings);
        }
        
    }


  

    public class AppInfo
    {
        public string ApplicaionName { get; set; } = "BlueLotus ToDo";
    }

    public class AppSettings
    {
        public AppInfo AppInfo { get; set; }
        public APISettings APISettings { get; set; }

        public AppSettings()
        {
            AppInfo=new AppInfo(); 
            APISettings=new APISettings();
            APISettings.ApplicationId = "1aa6a39b-5f54-4905-880a-a52733fd6105";
            APISettings.BaseURL = "https://bluelotus360.co/CoreAPI/api";

        }
    }
}
