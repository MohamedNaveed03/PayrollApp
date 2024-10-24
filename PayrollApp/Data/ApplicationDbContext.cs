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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTitle>()
                .HasIndex(j => j.Code)  // Specify the property for the index
                .IsUnique();            // Set it to unique

            // for employe id

            modelBuilder.Entity<Employee>()
            .HasIndex(j => j.Code)  
            .IsUnique();
        }
    }

}
