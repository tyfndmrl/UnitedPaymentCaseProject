using System.Net;

namespace UnitedPayment.Integration.Payzee.Models.ResponseModels
{
    public class LoginResponseModel
    {
        public bool Fail { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public LoginResultModel Result { get; set; }
        public string Count { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }

        public class LoginResultModel
        {
            public string UserId { get; set; }
            public string Token { get; set; }
        }
    }
}
