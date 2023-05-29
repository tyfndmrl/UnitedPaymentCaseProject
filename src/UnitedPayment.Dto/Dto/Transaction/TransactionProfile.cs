using AutoMapper;
using UnitedPayment.DTO.Dto.Transaction.RequestModels;
using UnitedPayment.DTO.Dto.Transaction.ResponseModels;

namespace UnitedPayment.DTO.Dto.Transaction
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionRequestModel, DDD.Entities.Transaction>();
            CreateMap<DDD.Entities.Transaction, TransactionResponseModel>();
        }
    }
}
