using NUnit.Framework;

namespace Grades.Tests
{
    [TestFixture]
    public class GradeBookTests
    {
        [Test]
        public void ComputeHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.HighestGrade);
        }
        
        [Test]
        public void ComputeLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(75);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(75, result.LowestGrade);
        }
        
        [Test]
        public void ComputeAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(75);
            book.AddGrade(89.5f);
            book.AddGrade(91);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }
    }
}