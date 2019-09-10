using System;

namespace Grades
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            book.NameChanged += new NameChangedDelegate(OnNameChanged);
//            book.NameChanged = new NameChangedDelegate(OnNameChanged2); // this will override above delegate definition
            book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            book.Name = "Hung's grade book";
            book.Name = "Grade book";
            book.AddGrade(88);
            book.AddGrade(99);
            book.AddGrade(93);
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:C}", description, result);
//            Console.WriteLine($"{description}: {result}");
        }
        
        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing name from \"{existingName}\" to \"{newName}\"");
        }
        
        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***********");
        }
    }
}