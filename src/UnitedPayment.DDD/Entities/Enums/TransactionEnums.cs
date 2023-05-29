namespace UnitedPayment.DDD.Entities.Enums
{
    public enum TransactionType
    {
        Sale,
        Void,
        Refund
    }

    public enum TransactionStatus
    {
        Pending,
        Success,
        Failure
    }

}