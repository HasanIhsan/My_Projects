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
            NavigationService._Navigate += Navigate;

            //set inital usercontrol;
            Navigate("UserControlA");
        }


        private void Navigate(string userControlName)
        {
            switch (userControlName)
            {
                case "UserControlA":
                    CurrentViewModel = new UserControlAViewModel();
                    break;
                case "UserControlB":
                    CurrentViewModel = new UserControlBViewModel();
                    break;
                    // Add more cases for additional UserControls if needed
            }
        }
    }
}
