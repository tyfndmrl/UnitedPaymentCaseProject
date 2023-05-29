namespace UnitedPayment.Repository.Repositories.Interfaces
{
    public interface IBulkRepository<TEntity> where TEntity : class
    {
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
