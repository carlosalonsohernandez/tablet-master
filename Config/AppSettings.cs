using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TabletMaster.Config
{
    internal class AppSettings
    {
        public static AppConfig config;

        //get the config path, might be worth using another method to get the path
        static string configPath = System.IO.Directory.GetParent(@"../../").FullName +
            Path.DirectorySeparatorChar + "Config/config.json";

        public static void Initialize()
        {
            //we set config to a new instance of the class that holds our settings
            config = new AppConfig();

            //build config file, bind to ConfigHandler instance
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(configPath);
            IConfigurationRoot configRoot = configBuilder.Build();
            configRoot.Bind(config);
        }
    }
}
