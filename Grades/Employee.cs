namespace Grades
{
    public class Employee
    {
        public static int NumberOfEmployees;
        private static int _counter;
        private string _name;

        // A read-write instance property:
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        // A read-only static property:
        public static int Counter => _counter;

        // A Constructor:
        public Employee()
        {
            // Calculate the employee's number:
            _counter = ++NumberOfEmployees;
        }
    }
}