using MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts;
using MediatorAndCQRSPatternWithMediatR.Infrastructure.DatabaseContext;

namespace MediatorAndCQRSPatternWithMediatR.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
