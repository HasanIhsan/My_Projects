using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Example.command;
using WPF_MVVM_Example.navigation;

namespace WPF_MVVM_Example.viewmodels
{
    public class UserControlBViewModel : ViewModelBase
    {
        private RelayCommand _navigateToACommand;

        public RelayCommand NavigateToACommand
        {
            get
            {
                return _navigateToACommand ?? (_navigateToACommand = new RelayCommand(NavigationHandler.GetNavigationAction("A")));
            }
        }

      
    }
}
