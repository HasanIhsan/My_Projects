using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarkLibrary
{
    public interface IEvaluation
    {

        public string Description { get; set; }
        public double BasisMarks { get; set; }
        public double EarnedMarks { get; set; }
        public double Weight { get; set; }




        public double CalcPercent( );

        public double CalcCourseMarks( );


    }
}
