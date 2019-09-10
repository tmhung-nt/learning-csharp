using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            name = "Empty";
            grades = new List<float>();
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook:ComputeStatistics");
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach (float grade in grades)
            {
                sum += grade;
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                stats.AverageGrade = sum / grades.Count;
            }

            return stats;
        }
        public override void WriteGrades(TextWriter destination)
        {
            foreach (float grade in grades)
            {
                destination.WriteLine(grade);
            }
        }
        protected readonly List<float> grades;
    }
}