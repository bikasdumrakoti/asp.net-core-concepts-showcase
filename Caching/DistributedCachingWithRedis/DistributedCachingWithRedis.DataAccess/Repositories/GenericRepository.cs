using DistributedCachingWithRedis.DataAccess.DatabaseContext;
using DistributedCachingWithRedis.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DistributedCachingWithRedis.DataAccess.Repositories
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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
    }
}
