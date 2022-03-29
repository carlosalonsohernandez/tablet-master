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

namespace TabletMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point mousePos;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            mousePos = MouseFunctions.GetPosition(this);
            txtTop.Text = $"X = {mousePos.X} Y= {mousePos.Y}";
        }

        private void OnButtonSimulate(object sender, RoutedEventArgs e)
        {
            MouseFunctions.SimulateLeftClick(Convert.ToInt32(mousePos.X), Convert.ToInt32(mousePos.Y));
        }
    }
}
