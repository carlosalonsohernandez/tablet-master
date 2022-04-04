using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletMaster.Core;

namespace TabletMaster.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public HomeViewModel HomeVM { get; set; }

        private object currentView { get; set; }
        
        public object CurrentView
        {
            get { return this.currentView; }
            set
            {
                this.currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
        }
    }
}
