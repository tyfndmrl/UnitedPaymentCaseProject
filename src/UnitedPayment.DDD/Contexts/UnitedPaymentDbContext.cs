using Microsoft.EntityFrameworkCore;
using UnitedPayment.DDD.Entities;
using UnitedPayment.DDD.Entities.Bases.Interfaces;

namespace UnitedPayment.DDD.Contexts
{
    public class UnitedPaymentDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public UnitedPaymentDbContext(DbContextOptions<UnitedPaymentDbContext> options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(x => (x.Entity is IHasCreationDate || x.Entity is IHasModificationDate || x.Entity is ISoftDelete) &&
                (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            var now = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added && entry.Entity is IHasCreationDate creation)
                    creation.CreatedDate = now;

                else if ((entry.State == EntityState.Modified || entry.State == EntityState.Deleted) && entry.Entity is IHasModificationDate modification)
                    modification.LastModificationDate = now;

                if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete soft)
                {
                    entry.State = EntityState.Modified;
                    soft.IsDeleted = true;
                }

            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}