namespace PayrollApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
        public int YearsWorked { get; set; }
    }
}
