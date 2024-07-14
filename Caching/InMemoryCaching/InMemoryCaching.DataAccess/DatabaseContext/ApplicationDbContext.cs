using InMemoryCaching.Models;
using Microsoft.EntityFrameworkCore;

namespace InMemoryCaching.DataAccess.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
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
