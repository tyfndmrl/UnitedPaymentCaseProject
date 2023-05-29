namespace UnitedPayment.Repository.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Queryable { get; }
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task<TEntity> GetByIdAsync(object id);
        Task SaveChangesAsync();
    }
}
