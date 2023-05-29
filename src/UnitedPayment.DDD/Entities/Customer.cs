using System.ComponentModel.DataAnnotations.Schema;
using UnitedPayment.DDD.Entities.Bases;
using UnitedPayment.DDD.Entities.Enums;

namespace UnitedPayment.DDD.Entities
{
    [Table("Customers")]
    public class Customer : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; }
        public CustomerStatus Status { get; set; } = CustomerStatus.Inactive;
    }

}