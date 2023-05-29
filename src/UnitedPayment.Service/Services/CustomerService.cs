using AutoMapper;
using UnitedPayment.DDD.Entities;
using UnitedPayment.DTO.Dto.Customer.RequestModels;
using UnitedPayment.DTO.Dto.Customer.ResponseModels;
using UnitedPayment.Integration.NVI.Services.Interfaces;
using UnitedPayment.Repository.Repositories.Interfaces;
using UnitedPayment.Service.Services.Bases;
using UnitedPayment.Service.Services.Interfaces;

namespace UnitedPayment.Service.Services
{
    public class CustomerService : Service<IRepository<Customer>, Customer>, ICustomerService
    {
        private readonly IMernisService _mernisService;

        public CustomerService(IRepository<Customer> repository, IMapper mapper, IMernisService mernisService) : base(repository, mapper)
        {
            _mernisService = mernisService;
        }

        public async Task<CustomerResponseModel> AddAsync(CustomerRequestModel model)
        {
            var entity = _mapper.Map<Customer>(model);
            await Repository.AddAsync(entity);

            if (Int64.TryParse(model.IdentityNo, out Int64 identity))
            {
                var validate = await _mernisService.ValidateTCIdentityAsync(identity, model.Name, model.Surname, model.BirthDate.Year);
                if (validate)
                {
                    entity.IdentityNoVerified = true;
                    entity.Status = DDD.Entities.Enums.CustomerStatus.Active;
                    await Repository.UpdateAsync(entity);
                }
            }

            return _mapper.Map<CustomerResponseModel>(entity);
        }
    }
}
