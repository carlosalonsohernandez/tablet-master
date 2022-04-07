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
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand FunctionViewCommand { get; set; }
        public RelayCommand ContactViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public FunctionViewModel FunctionVM { get; set; }

        public ContactViewModel ContactVM { get; set; }

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
            FunctionVM = new FunctionViewModel();
            ContactVM = new ContactViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(p =>
            {
                CurrentView = HomeVM;
            });

            FunctionViewCommand = new RelayCommand(p =>
            {
                CurrentView = FunctionVM;
            });

            ContactViewCommand = new RelayCommand(p =>
            {
                CurrentView = ContactVM;
            });
        }
    }
}
