using MediatorAndCQRSPatternWithMediatR.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndCQRSPatternWithMediatR.Infrastructure.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DbInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Count() > 0)
                {
                    _dbContext.Database.Migrate();
                }
            }
            catch (Exception) { }

            return;
        }
    }
}
