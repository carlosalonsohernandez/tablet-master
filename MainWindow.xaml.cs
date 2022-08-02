using System;
using System.Windows;
using System.Drawing;
using System.Windows.Input;
using TabletMaster.Config;
using TabletMaster.Core;

namespace TabletMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Point mousePos;
        public MainWindow()
        {
            //On app startup, initialize with several methods
            InitializeComponent();
            AppSettings.Initialize();

            // Create a notifyIcon so application can hide to system tray
            System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();

            // Create system tray notify icon
            notifyIcon.Icon = new System.Drawing.Icon("appicon.ico");
            notifyIcon.Visible = true;

            // Add context menu strip to be able to exit when hidden in system tray
            notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Exit!", Image.FromFile("appicon.ico"),
                delegate (object sender, EventArgs args)
                {
                    this.Close();
                });

            // When system tray double clicked, bring app back to normal status
            notifyIcon.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
        }

        private void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            // If the config files are set up to hide to system tray, do so. Otherwise, the app closes normally.
            if (AppSettings.config.HideOnExit)
            {
                this.Hide();
            }
            else
            {
            this.Close();
            }
        }

        private void OnMinimizeClicked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void OnTopBarDragged(object sender, MouseButtonEventArgs e)
        {
            // Make app draggable when m1 is down on the top bar
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
