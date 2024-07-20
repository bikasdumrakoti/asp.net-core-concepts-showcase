using MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts;
using MediatorAndCQRSPatternWithMediatR.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndCQRSPatternWithMediatR.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
