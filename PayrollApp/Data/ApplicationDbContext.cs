using Microsoft.EntityFrameworkCore;
using PayrollApp.Models;

namespace PayrollApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
    }

}
