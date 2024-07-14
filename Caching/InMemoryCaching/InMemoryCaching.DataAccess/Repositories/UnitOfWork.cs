using InMemoryCaching.DataAccess.DatabaseContext;
using InMemoryCaching.RepositoryContracts;

namespace InMemoryCaching.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IEmployeeRepository Employee { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Employee = new EmployeeRepository(_dbContext);
        }
    }
}
