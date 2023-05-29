using AutoMapper;
using UnitedPayment.DDD.Entities;
using UnitedPayment.Repository.Repositories.Interfaces;
using UnitedPayment.Service.Services.Bases;
using UnitedPayment.Service.Services.Interfaces;

namespace UnitedPayment.Service.Services
{
    public class TransactionService : Service<IRepository<Transaction>, Transaction>, ITransactionService
    {
        public TransactionService(IRepository<Transaction> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
