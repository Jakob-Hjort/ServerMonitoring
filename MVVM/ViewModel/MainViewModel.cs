using System;
using Moderndesign.Core;
using Moderndesign.MVVM.ViewModel;

namespace Moderndesign.MVVM.ViewModel
{
    internal class MainViewModel : ObersvableObjects
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand LoadViewCommand { get; set; }


        public HomeViewModel HomeVm { get; set; }

        public LoadViewModel LoadVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            LoadVm = new LoadViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVm;
            });

            LoadViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoadVm;
            });
        }

    }
}
