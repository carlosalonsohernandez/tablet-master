using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;

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
            InitializeComponent();

            System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("appicon.ico");
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if(WindowState == System.Windows.WindowState.Minimized){this.Hide();}

            base.OnStateChanged(e);
        }

        private void SimulatingEventHandler(object sender, RoutedEventArgs e)
        {
            MouseFunctions.SimulateLeftClick(Convert.ToInt32(mousePos.X), Convert.ToInt32(mousePos.Y));
        }

        private void ClosingEventHandler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizingEventHandler(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void GridDraggingEventHandler(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
