using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Example.navigation;

namespace WPF_MVVM_Example.viewmodels
{
    public class MainViewModel :ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private NavigationHandler _navigationHandler;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
               _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {
             
            _navigationHandler = new NavigationHandler(this);

            NavigationService._Navigate += _navigationHandler.Navigate;

            //set inital usercontrol;
            //Navigate("UserControlA");
            _navigationHandler.Navigate("UserControlA");
        }


     
    }
}
