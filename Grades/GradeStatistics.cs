using System;

namespace Grades
{
    public class GradeStatistics
    {
        public string LetterGrade
        {
            get
            {
                string result;
                if (Math.Round(AverageGrade) >= 90)
                    result = "A";
                else if (Math.Round(AverageGrade) >= 80)
                    result = "B";
                else if (Math.Round(AverageGrade) >= 70)
                    result = "C";
                else if (Math.Round(AverageGrade) >= 60)
                    result = "D";
                else
                    result = "F";
                return result;
            }
        }

        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below average";
                        break;
                    default:
                        result = "Failing";
                        break;
                }

                return result;
            }
        }

        public float HighestGrade = 0;
        public float LowestGrade = float.MaxValue;
        public float AverageGrade = 0;
    }
}