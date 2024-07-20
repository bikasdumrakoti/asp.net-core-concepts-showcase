namespace MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> CreateAsync(T entity);

        Task<T?> GetByIdAsync(int id);
    }
}
