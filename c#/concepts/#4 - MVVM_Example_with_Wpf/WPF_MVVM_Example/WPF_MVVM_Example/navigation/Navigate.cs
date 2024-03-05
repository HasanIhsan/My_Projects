using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Example.navigation
{
    public class Navigate
    {

        public static void NavigateToBE() 
        {
            NavigationService.NavigateTo("UserControlB");
        }


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
