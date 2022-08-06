using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletMaster.Core;

namespace TabletMaster.Config
{
    public class SavedHotkeys
    {
        private List<HotkeyFunction> savedHotkeys = new List<HotkeyFunction>();

        // This will save a file containing the savedHotkeys and their values
        public void Save()
        {

        }

        // This method will check if the saved hotkeys exist and present the user with a choice to use them
        public bool CheckIfExist()
        {
            return false;
        }

        // This method will parse the already saved hotkeys and add it to the program
        public void UseSavedHotkeys()
        {

        }

        // If the user chooses to overwrite the hotkeys, this method will handle that.
        public void OverwriteHotkeys()
        {

        }

        // This will run every time a hotkey gets added, adding it to the savedHotkeys list
        public void addHotkey()
        {

        }
    }
}
