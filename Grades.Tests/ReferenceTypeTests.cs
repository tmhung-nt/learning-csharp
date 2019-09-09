using System;
using System.Threading;
using NUnit.Framework;

namespace Grades.Tests
{
    [TestFixture]
    public class ReferenceTypeTests
    {
        [Test]
        public void VariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Hung's book";
            Assert.AreEqual(g2.Name, g1.Name);
        }
    }
}