using PayrollApp.Models;

public class Payroll
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalHoursWorked { get; set; }

    public virtual Employee Employee { get; set; }
}
