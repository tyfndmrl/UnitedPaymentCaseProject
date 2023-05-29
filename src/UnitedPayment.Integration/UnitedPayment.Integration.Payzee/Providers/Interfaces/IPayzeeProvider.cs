using UnitedPayment.Integration.Payzee.Models.RequestModels;
using UnitedPayment.Integration.Payzee.Models.ResponseModels;

namespace UnitedPayment.Integration.Payzee.Providers.Interfaces
{
    public interface IPayzeeProvider
    {
        Task<LoginResponseModel> Authentication();
        Task<NoneSecurePaymentResponseModel> NoneSecurePayment(NoneSecurePaymentRequestModel model);
    }
}
