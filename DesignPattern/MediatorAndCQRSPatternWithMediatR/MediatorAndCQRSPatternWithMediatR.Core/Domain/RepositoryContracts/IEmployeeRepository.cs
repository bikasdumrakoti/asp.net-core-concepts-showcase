using MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities;

namespace MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
