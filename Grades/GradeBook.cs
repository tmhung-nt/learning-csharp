using System;
using System.Collections.Generic;
using System.IO;
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

        public virtual GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook:ComputeStatistics");
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
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be null or empty");
                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs {ExistingName = _name, NewName = value};
                    NameChanged(this, args);
                }

                _name = value;
            }
        }

        public event NameChangedDelegate NameChanged;
        protected readonly List<float> _grades;
        private string _name;

        public void WriteGrades(TextWriter destination)
        {
            foreach (float grade in _grades)
            {
                destination.WriteLine(grade);
            }
        }
    }
}