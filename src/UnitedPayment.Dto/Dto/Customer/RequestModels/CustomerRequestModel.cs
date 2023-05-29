using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedPayment.DTO.Dto.Customer.RequestModels
{
    public class CustomerRequestModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNo { get; set; }
    }
}
