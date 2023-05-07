using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class CompareExpressions : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            if(x == y)
            {
                return 0;
            }else
                return 1;

             
        }
    }
}
