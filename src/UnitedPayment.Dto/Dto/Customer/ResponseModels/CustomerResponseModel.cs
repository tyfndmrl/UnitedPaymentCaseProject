using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedPayment.DDD.Entities.Enums;

namespace UnitedPayment.DTO.Dto.Customer.ResponseModels
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNo { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IdentityNoVerified { get; set; }
        public CustomerStatus Status { get; set; }
    }
}
