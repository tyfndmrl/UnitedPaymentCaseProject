using AutoMapper;
using UnitedPayment.DTO.Dto.Customer.RequestModels;
using UnitedPayment.DTO.Dto.Customer.ResponseModels;

namespace UnitedPayment.DTO.Dto.Customer
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerRequestModel, DDD.Entities.Customer>();
            CreateMap<DDD.Entities.Customer, CustomerResponseModel>();
        }
    }
}
