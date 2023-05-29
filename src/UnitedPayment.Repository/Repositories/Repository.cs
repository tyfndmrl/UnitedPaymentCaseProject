using UnitedPayment.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UnitedPayment.Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;
        protected DbSet<TEntity> DbSet { get; }
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> Queryable => DbSet;

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity); 
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id) => await DbSet.FindAsync(id);

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
