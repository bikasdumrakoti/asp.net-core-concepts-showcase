using InMemoryCaching.DataAccess.DatabaseContext;
using InMemoryCaching.Models;
using InMemoryCaching.RepositoryContracts;

namespace InMemoryCaching.DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
