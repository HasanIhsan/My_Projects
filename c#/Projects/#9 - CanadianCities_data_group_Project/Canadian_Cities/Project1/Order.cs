using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class OrderByPopulation : IComparer<CityInfo>
    {
        public int Compare(CityInfo? x, CityInfo? y)
        {
            return x == null ? 0 :
                x.Population.CompareTo(y?.Population);
        }
    }
}
