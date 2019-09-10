﻿using System;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook:ComputeStatistics");
            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(lowest, grade);
            }

            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}