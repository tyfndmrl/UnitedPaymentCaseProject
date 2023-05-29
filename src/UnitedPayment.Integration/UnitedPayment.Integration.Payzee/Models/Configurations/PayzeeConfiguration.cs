using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedPayment.Integration.Payzee.Models.Configurations
{
    public class PayzeeConfiguration
    {
        public string AuthenticationBaseUrl { get; set; }
        public string AuthenticationUrl { get; set; }
        public string NoneSecurePaymentBaseUrl { get; set; }
        public string NoneSecurePaymentUrl { get; set; }

        public string ApiKey { get; set; }
        public string Email { get; set; }
        public string Lang { get; set; }
    }
}
