using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class CityPopulationChangeEvent : EventArgs
    {
        public CityInfo CurrentCity { get; set; }
        public int NewPop { get; set; }

        public CityPopulationChangeEvent(ref CityInfo currentCity, int newPop)
        {
            CurrentCity = currentCity;
            NewPop = newPop;
        }
    }
}
