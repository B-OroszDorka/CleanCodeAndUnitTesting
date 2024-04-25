namespace Week05
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public int CalculateSalary() 
        { 
            return Salary; 
        }
    }
}
