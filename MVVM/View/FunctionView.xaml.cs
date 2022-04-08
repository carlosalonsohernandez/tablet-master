using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using TabletMaster.Core;
using TabletMaster.Config;
using System.Drawing;
using System.Windows;

namespace TabletMaster.MVVM.View
{
    /// <summary>
    /// Interaction logic for FunctionView.xaml
    /// </summary>
    public partial class FunctionView : UserControl
    {
        System.Drawing.Point mousePos;
        public FunctionView()
        {
            InitializeComponent();
            HotkeysHandler.StartSysHook();

            // Create hotkey to save the mouse position
            HotkeysHandler.AddHotkey(new HotkeyFunction(ModifierKeys.Control, Key.S, () => { SaveMousePos(); }));

            // Populate the text of the textBox on startup with the default modifier and key
            tbCurrentHotkey.Text = $"Modifier: {AppSettings.config.Modifier} Key: {AppSettings.config.Key}";
        }

        public bool IsTextAlphabetic(string content)
        {
            Regex reg = new Regex("[A-Za-z]");

            return !reg.IsMatch(content);
        }
        
        /// <summary>
        /// This method saves the current mouse position when it is called. It currently pairs with a list
        /// for some quick and dirty debugging but will eventually stand on its own
        /// </summary>
        public void SaveMousePos()
        {
            mousePos = System.Windows.Forms.Control.MousePosition;
            lbHotkeysTracked.Items.Add($"X = {mousePos.X} Y = {mousePos.Y}");
            AppSettings.config.SavedMousePositionX = mousePos.X;
            AppSettings.config.SavedMousePositionY = mousePos.Y;
            lbHotkeysTracked.Items.Add($"Saved AppSettings: X = {AppSettings.config.SavedMousePositionX} Y = {AppSettings.config.SavedMousePositionY}");

        }

        /// <summary>
        /// This method checks the textBox for non-letter input and stops it from happening
        /// </summary>
        private void textBoxKeyChecker(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAlphabetic(e.Text);
        }

        private void btnSimulateClicked(object sender, RoutedEventArgs e)
        {
            MouseFunctions.SimulateLeftClick(Convert.ToInt32(mousePos.X), Convert.ToInt32(mousePos.Y));
        }

        private void btnConfirmClicked(object sender, RoutedEventArgs e)
        {
            //If the user has selected something on both the comboBox and textBox
            if(cbModifier.SelectedIndex > -1 && textBoxKey.Text.Length > 0)
            {
                MessageBox.Show("Confirmed!");
                AppSettings.config.Modifier = cbModifier.Text;
                AppSettings.config.Key = textBoxKey.Text;

                tbCurrentHotkey.Text = $"Modifier: {AppSettings.config.Modifier} Key: {AppSettings.config.Key}";
            }
            else
            {
                MessageBox.Show("Not enough information!");
            }
        }
    }
}
