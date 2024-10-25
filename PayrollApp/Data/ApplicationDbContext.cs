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
            .HasIndex(j => j.Code) 
            .IsUnique(); 

            modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Code) 
            .IsUnique(); 
            
            modelBuilder.Entity<JobTitle>()
                .HasMany(j => j.Employees)
                .WithOne(e => e.JobTitle)
                .HasForeignKey(e => e.JobTitleId); 
          
            modelBuilder.Entity<JobTitle>().HasData(
                new JobTitle { Id = 1, Code = "SM", Description = "Sales Manager", Salary = 20.00M },
                new JobTitle { Id = 2, Code = "HR", Description = "HR Manager", Salary = 25.00M }
            );
        }

    }

}
