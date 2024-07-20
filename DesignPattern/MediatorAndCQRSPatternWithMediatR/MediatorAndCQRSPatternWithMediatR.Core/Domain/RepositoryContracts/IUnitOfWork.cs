namespace MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }

        Task Save();
    }
}
