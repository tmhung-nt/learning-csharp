using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Grades.Tests
{
    [TestFixture]
    public class ReferenceTypeTests
    {
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