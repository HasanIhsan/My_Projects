namespace CourseMarkLibrary
{
    public class Course : ICourse
    {
        List<IEvaluation> NewEvaluationList;

        public Course()
        {
            NewEvaluationList = new List<IEvaluation>();
        }

         IEvaluation ICourse.AddEvaluation(string desc, double basic, double earned, double weight)
        {
            Evaluation newEvalu= new Evaluation();

            newEvalu.Description = desc;
            newEvalu.BasisMarks= basic;
            newEvalu.EarnedMarks = earned;
            newEvalu.Weight = weight;

            NewEvaluationList.Add(newEvalu);

            return newEvalu;
          
        }

      

         double ICourse.CalcPercent()
        {
            //100 x total-earned - marks / total - weight
            //Where total-earned - marks is the result returned by CalcTotalEarnedMarks() 
            //and total-weight is the result returned by CalcTotalWeight().
 
            
            double TotalEarned = (this as ICourse).CalcTotalEarnedMarks();
            double TotalWeight = (this as ICourse).CalcTotalWeight();



            return 100 * TotalEarned / TotalWeight;
        }

         double ICourse.CalcTotalEarnedMarks()
        {
            double SumofTotalMarksEarned = 0.0;
            foreach(var e in NewEvaluationList)
            {
                SumofTotalMarksEarned += e.CalcCourseMarks();
            }

            return SumofTotalMarksEarned;
        }

         double ICourse.CalcTotalWeight()
        {
            double SumOfWeight = 0.0;

            foreach(var e in NewEvaluationList)
            {
                SumOfWeight += e.Weight;
            }

            return SumOfWeight;
        }
    }
}