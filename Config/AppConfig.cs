using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TabletMaster.Config
{
    /// <summary>
    /// This class handles the different configurations that are available in the JSON config file.
    /// </summary>
    internal class AppConfig
    {
        public bool HideOnExit { get; set; }
        public int SavedMousePositionX { get; set; }
        public int SavedMousePositionY { get; set; }
        public string Modifier { get; set; }
        public string Key { get; set; }

        private void editJSON(string token, string replacement)
        {
            string jsonString = File.ReadAllText(AppSettings.getConfigPath());
            JObject jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
            JToken jToken = jObject.SelectToken(token);
            jToken.Replace(replacement);
            string updatedJsonString = jObject.ToString();
            File.WriteAllText("myfile.json", updatedJsonString);
        }
    }
}
