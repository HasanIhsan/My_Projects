using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarkLibrary
{
    public interface ICourse
    {

        public IEvaluation AddEvaluation(string desc, double basic, double earned, double weight);

        public double CalcTotalWeight();

        public double CalcTotalEarnedMarks();
        public double CalcPercent();

        
    }
}
