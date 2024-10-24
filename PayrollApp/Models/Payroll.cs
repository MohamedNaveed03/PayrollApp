namespace PayrollApp.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalHoursWorked { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Housing { get; set; }
        public decimal Transport { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
