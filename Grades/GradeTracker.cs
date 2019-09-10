using System;
using System.IO;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);

        public string Name
        {
            get => name.ToUpper();
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be null or empty");
                if (name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs {ExistingName = name, NewName = value};
                    NameChanged(this, args);
                }

                name = value;
            }
        }
        public event NameChangedDelegate NameChanged;
        protected string name;

    }
}