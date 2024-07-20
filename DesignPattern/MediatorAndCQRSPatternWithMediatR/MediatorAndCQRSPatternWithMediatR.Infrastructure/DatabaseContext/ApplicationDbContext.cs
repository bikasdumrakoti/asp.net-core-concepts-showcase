using MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndCQRSPatternWithMediatR.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed to Employees.
            string employeesJson = File.ReadAllText("JSONs\\employees.json");
            List<Employee>? employees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(employeesJson);

            if (employees is not null)
            {
                foreach (Employee employee in employees)
                {
                    modelBuilder.Entity<Employee>().HasData(employee);
                }
            }
        }
    }
}
