using System;
using System.IO;
using System.Net;

namespace Grades
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();
            book.NameChanged += OnNameChanged;

            Console.Write("Enter a name: ");
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult(stats.Description, stats.Description);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(88);
            book.AddGrade(99);
            book.AddGrade(93);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }
        
        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from \"{args.ExistingName}\" to \"{args.NewName}\"");
        }
    }
}