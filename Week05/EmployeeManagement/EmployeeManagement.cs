namespace Week05
{
    internal class EmployeeManagement
    {
        private List<Employee> _employees = new List<Employee>();

        public EmployeeManagement()
        {
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
        public int CalculatePayroll()
        {
            var payrollCalculator = new PayrollCalculator();
            return payrollCalculator.CalculatePayroll(_employees);
        }
        public string GenerateReports()
        {
            var reportGenerator = new ReportGenerator();
            return reportGenerator.GenerateReports(_employees);
        }
        public void PromoteEmployee(Employee employee)
        {
            // Code to handle employee promotion logic
        }
    }
}
