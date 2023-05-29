using System;
using System.ComponentModel.DataAnnotations.Schema;
using UnitedPayment.DDD.Entities.Bases;
using UnitedPayment.DDD.Entities.Enums;

namespace UnitedPayment.DDD.Entities
{
    [Table("Transactions")]
    public class Transaction : AuditableEntity<int>
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string CardPan { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public TransactionStatus Status { get; set; }
    }

}