using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabletMaster.Core;

namespace TabletMaster.Config
{
    public class SavedHotkeys
    {
        // Build a path to the roaming folder of AppData for current user
        private static string appFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), //The roaming folder for the current user
            "TabletMaster"); //The new folder

        private List<HotkeyFunction> savedHotkeys = new List<HotkeyFunction>();

        // This method will check if the saved hotkeys exist and present the user with a choice to use them

        public static void CheckIfExist()
        {
            string filePath = Path.Combine(appFolder, "savedhotkeys.txt");

            if (File.Exists(filePath))
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Saved hotkeys found! Would you like to use them?", "User Confirmation", buttons);
                if (result == DialogResult.Yes)
                {
                    UseSavedHotkeys(filePath);
                    MessageBox.Show("Hotkeys Updated!", "SUCCESS: Hotkeys Updated");
                }
                else
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("There was no saved hotkeys found!");
                return;
            }
        }

        // This will save a file containing the savedHotkeys and their values
        public static void Save(List<HotkeyFunction> hotkeys)
        {
            string filePath = Path.Combine(appFolder, "savedhotkeys.txt");

            //if a file already exists
            if (File.Exists(filePath))
            {
                // ask user to overwrite
                string message = "Saved hotkeys found! Would you like to overwrite them?";
                string title = "User Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                
                //if yes, overwrite. If no, return.
                if (result == DialogResult.Yes)
                {
                    File.Delete(filePath);
                    CreateAndWriteFile(filePath, hotkeys);
                }
                else
                {
                    return;
                }

            }
            else
            {
                //Create the directory and create and write the file!
                Directory.CreateDirectory(appFolder);
                CreateAndWriteFile(filePath, hotkeys);
            }

        }

        private static void CreateAndWriteFile(string filePath, List<HotkeyFunction> hotkeys)
        {
            try
            {
                using(StreamWriter sw = File.CreateText(filePath))
                {
                    foreach(var hotkey in hotkeys)
                    {
                        sw.WriteLine($"{hotkey.Modifier},{hotkey.Key},{hotkey.getMousePos().getMouseX()},{hotkey.getMousePos().getMouseY()}");
                    }
                }
                MessageBox.Show("File Written!", "SUCCESS: File Writing");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString(), "ERROR: EXCEPTION THROWN");
            }
        }

        // This method will parse the already saved hotkeys and add it to the program
        private static void UseSavedHotkeys(string filePath)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string content;
                while((content = sr.ReadLine()) != null)
                {
                    var splitLine = content.Split(',');
                    var tempMousePos = new MousePosition(Int32.Parse(splitLine[2]), Int32.Parse(splitLine[3]));
                    var newHotkey = new HotkeyFunction(splitLine[0], splitLine[1], () =>
                    {
                        MouseFunctions.SimulateLeftClick(tempMousePos);
                    }, tempMousePos);

                    HotkeysHandler.AddHotkey(newHotkey);
                }
            }
        }
    }
}
