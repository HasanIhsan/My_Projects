using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarkLibrary
{
    internal class Evaluation : IEvaluation
    {

        string desc = "";
        double BasisMark = 0.0;
        double EarnedMark = 0.0;
        double weight = 0.0;

       public string Description
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
            }
        }

        public double BasisMarks
        {
            get
            {
                return BasisMark;
            }
            set
            {
                BasisMark = value;
            }
        }


        public double EarnedMarks
        {
            get
            {
                return EarnedMark;
            }
            set
            {
                EarnedMark = value;
            }
        }


        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }



       

        public double CalcCourseMarks( )
        {
            return Weight * EarnedMarks / BasisMarks;
        }

        public double CalcPercent( )
        {
             
            return 100 * EarnedMarks / BasisMarks;

        }
    }
}
