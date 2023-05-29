using System.Net;

namespace UnitedPayment.Integration.Payzee.Models.ResponseModels
{
    public class NoneSecurePaymentResponseModel
    {
        public bool Fail { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public NoneSecurePaymentResultModel Result { get; set; }

        public class NoneSecurePaymentResultModel
        {
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public string OrderId { get; set; }
            public string TxnType { get; set; }
            public string TxnStatus { get; set; }
            public string VposId { get; set; }
            public string VposName { get; set; }
            public string AuthCode { get; set; }
            public string HostReference { get; set; }
            public string TotalAmount { get; set; }
        }
    }
}
