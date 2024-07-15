using DistributedCachingWithRedis.DataAccess.DatabaseContext;
using DistributedCachingWithRedis.Models;
using DistributedCachingWithRedis.RepositoryContracts;

namespace DistributedCachingWithRedis.DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
