using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Grades.Tests
{
    [TestFixture]
    public class TypeTests
    {
        [Test]
        public void UppercaseString()
        {
            string name = "hung";
            
            name.ToUpper();
            Assert.AreNotEqual("HUNG", name);

            string name2 = name.ToUpper();
            Assert.AreEqual("HUNG", name2);
        }
        
        [Test]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2020, 11, 11);
            date.AddDays(1);
            DateTime date2 = date.AddDays(1);
            Assert.AreNotEqual(12, date.Day);
            Assert.AreEqual(12, date2.Day);
        }
        
        [Test]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;
            
            GiveBookAName(ref book2);
            Assert.AreEqual("A GradeBook", book2.Name);
        }

        private void GiveBookAName(ref GradeBook book)
        {
            book = new GradeBook();
            book.Name = "A GradeBook";
        }
        
        [Test]
        public void ValueTypesPassByValue()
        {
            int x = 100;
            IncrementNumber(ref x);
//            Assert.AreNotEqual(101, x);
            Assert.AreEqual(101, x);
        }

        private void IncrementNumber(ref int num)
        {
            num += 1;
        }
        
        [Test]
        public void StringComparasions()
        {
            string name1 = "Hung";
            string name2 = "hung";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }
        [Test]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Hung's book";
            Assert.AreEqual(g2.Name, g1.Name);
        }

        [Test]
        public void IntVariableHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 += 2;
            Assert.AreNotEqual(x1, x2);
        }
    }
}