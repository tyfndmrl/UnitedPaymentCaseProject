using UnitedPayment.DTO.Dto.Customer.RequestModels;
using UnitedPayment.DTO.Dto.Customer.ResponseModels;
using UnitedPayment.Service.Services.Bases.Interfaces;

namespace UnitedPayment.Service.Services.Interfaces
{
    public interface ICustomerService : IService
    {
        Task<CustomerResponseModel> AddAsync(CustomerRequestModel model);
    }
}
