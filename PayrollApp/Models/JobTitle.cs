﻿namespace PayrollApp.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
