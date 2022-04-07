using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace TabletMaster.MVVM.View
{
    /// <summary>
    /// Interaction logic for ContactView.xaml
    /// </summary>
    public partial class ContactView : UserControl
    {
        public ContactView()
        {
            InitializeComponent();
        }

        private void OnRepoButtonClicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/carlosalonsohernandez/tablet-master",
                UseShellExecute = true
            });
        }
    }

}
