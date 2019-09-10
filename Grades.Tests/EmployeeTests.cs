using NUnit.Framework;

namespace Grades.Tests
{
    [TestFixture]
    public class TestEmployee
    {
        [Test]
        public void TestNumberOfEmployees()
        {
            Employee.NumberOfEmployees = 107;
            Employee e1 = new Employee();
            e1.Name = "Claude Vige";

            Assert.AreEqual(108, Employee.NumberOfEmployees);
            Assert.AreEqual("Claude Vige", e1.Name);
        }
        /* Output:
            Employee number: 108
            Employee name: Claude Vige
        */
    }
}