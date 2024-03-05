using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Example.command;
using WPF_MVVM_Example.navigation;

namespace WPF_MVVM_Example.viewmodels
{
    public class UserControlAViewModel : ViewModelBase
    {
        private RelayCommand _navigateToBCommand;
        

        public RelayCommand NavigateToBCommand
        {
            get
            {
                return _navigateToBCommand ?? (_navigateToBCommand = new RelayCommand(Navigate.GetNavigationAction("B")));
            }
        }

        private void NavigateToB()
        {
           
            // Implement navigation logic to UserControlB
            NavigationService.NavigateTo("UserControlB");
        }
    }
}
