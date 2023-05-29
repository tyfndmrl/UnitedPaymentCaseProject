using Microsoft.EntityFrameworkCore;
using UnitedPayment.Repository.Repositories.Interfaces;

namespace UnitedPayment.Repository.Repositories
{
    public abstract class BulkRepository<TEntity> : IBulkRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;
        protected DbSet<TEntity> DbSet { get; }
        public BulkRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
