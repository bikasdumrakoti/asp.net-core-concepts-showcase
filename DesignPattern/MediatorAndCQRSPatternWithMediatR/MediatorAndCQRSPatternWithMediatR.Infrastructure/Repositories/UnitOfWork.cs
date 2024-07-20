using MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts;
using MediatorAndCQRSPatternWithMediatR.Infrastructure.DatabaseContext;

namespace MediatorAndCQRSPatternWithMediatR.Infrastructure.Repositories
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

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
