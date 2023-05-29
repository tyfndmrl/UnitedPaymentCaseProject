namespace UnitedPayment.Integration.Payzee.Models.RequestModels
{
    public class LoginRequestModel
    {
        public string ApiKey { get; set; }
        public string Lang { get; set; }
        public string Email { get; set; }
    }
}
