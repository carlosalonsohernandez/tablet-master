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

        public bool DoesExist()
        {
            string filePath = Path.Combine(appFolder, "savedhotkeys.txt");

            if (File.Exists(filePath))
            {
                string message = "Saved hotkeys found! Would you like to use them?";
                string title = "User Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


            return false;
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
                    CreateAndWriteFile(filePath);
                    MessageBox.Show("File Written!");
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
                CreateAndWriteFile(filePath);
                MessageBox.Show("File Written!");
            }

        }

        private static void CreateAndWriteFile(string filePath)
        {
            try
            {
                using(StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine($"New file created: {DateTime.Now.ToString()}");
                    sw.WriteLine("One more line!!");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString(), "ERROR: EXCEPTION THROWN");
            }
        }

        // This method will parse the already saved hotkeys and add it to the program
        public void UseSavedHotkeys()
        {

        }
    }
}
