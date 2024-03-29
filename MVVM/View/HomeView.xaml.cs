﻿using System;
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
using TabletMaster.Config;

namespace TabletMaster.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void SystemTrayCheckboxChanged(object sender, RoutedEventArgs e)
        {
            //Whenever the checkbox is changed, we update the config according to it
            if (SystemTrayCheckbox.IsChecked == true)
            {
                AppSettings.config.HideOnExit = true;
            }
            else
            {
                AppSettings.config.HideOnExit = false;
            }
        }

    }
}
