using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
