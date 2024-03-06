using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Example.viewmodels;

namespace WPF_MVVM_Example.navigation
{
    public class NavigationHandler
    {
        private MainViewModel _mainViewModel;


        public NavigationHandler(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void Navigate(string userControlName)
        {
            switch (userControlName)
            {
                case "UserControlA":
                    _mainViewModel.CurrentViewModel = new UserControlAViewModel();
                    break;
                case "UserControlB":
                    _mainViewModel.CurrentViewModel = new UserControlBViewModel();
                    break;
                    // Add more cases for additional UserControls if needed
            }
        }

        //putting all navigation in one file so its simpler to add and change things in the furture
        //aside from addin the new viewmodel, and updating the swtich in the mainviewmodel 
        //you can simple add a new path in this switch case and invoke it from the viewmodel classes:
        //ex: return _navigateToBCommand ?? (_navigateToBCommand = new RelayCommand(Navigate.GetNavigationAction("B")));
        public static Action GetNavigationAction(string navto)
        {

            Debug.WriteLine(navto);
            switch (navto)
            {
                case "A":
                    return () => NavigationService.NavigateTo("UserControlA");
                case "B":
                    return () => NavigationService.NavigateTo("UserControlB");
                default:
                    return () => { /* default action or throw an exception */ };
            }
        }


    }
}
