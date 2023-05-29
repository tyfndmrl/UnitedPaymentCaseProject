namespace UnitedPayment.DDD.Entities.Bases.Interfaces
{
    public interface IAuditableEntity : IHasCreationDate, IHasModificationDate, ISoftDelete
    {
    }
}
