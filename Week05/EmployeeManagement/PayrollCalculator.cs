namespace Week05
{
    internal class PayrollCalculator
    {
        public int CalculatePayroll(List<Employee> employees)
        {
            int totalPayroll = 0;
            foreach (var employee in employees)
            {
                totalPayroll += employee.CalculateSalary();
            }
            return totalPayroll;
        }
    }
}
