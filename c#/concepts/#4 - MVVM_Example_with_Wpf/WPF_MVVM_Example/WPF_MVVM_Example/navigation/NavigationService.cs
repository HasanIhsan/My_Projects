using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Example.navigation
{
    public static class NavigationService
    {
        public static Action<string> _Navigate;

        public static void NavigateTo(string usercontrol)
        {
            _Navigate?.Invoke(usercontrol);
        }
    }
}
