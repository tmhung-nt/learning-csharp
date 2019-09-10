using System;
using System.Collections.Generic;
using System.Threading;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
            _name = "Empty";
            _grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            _grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach (float grade in _grades)
            {
                sum += grade;
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                stats.AverageGrade = sum / _grades.Count;
            }

            return stats;
        }

        public string Name
        {
            get => _name.ToUpper();
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (_name != value)
                    {
                        NameChanged(_name, value);
                    }
                    _name = value;
                }
            }
        }

        public event NameChangedDelegate NameChanged;
        private readonly List<float> _grades;
        private string _name;
    }
}