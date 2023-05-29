using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UnitedPayment.Repository.Repositories.Interfaces;
using UnitedPayment.Service.Services.Bases.Interfaces;

namespace UnitedPayment.Service.Services.Bases
{
    public abstract class Service<TRepository, TEntity> : IService where TRepository : IRepository<TEntity> where TEntity : class
    {
        protected readonly TRepository Repository;
        protected readonly IMapper _mapper;

        public Service(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async virtual Task<TResponseDto> AddAsync<TRequestDto, TResponseDto>(TRequestDto model) where TRequestDto : class, new()
        {
            var entity = _mapper.Map<TEntity>(model);
            entity = await Repository.AddAsync(entity);

            return _mapper.Map<TResponseDto>(entity);
        }

        public async virtual Task<TResponseDto> UpdateAsync<TRequestDto, TResponseDto>(object id, TRequestDto model) where TRequestDto : class, new()
        {
            var entity = await Repository.GetByIdAsync(id);
            entity = _mapper.Map(model, entity);
            await Repository.UpdateAsync(entity);

            return _mapper.Map<TResponseDto>(entity);
        }

        public async virtual Task DeleteAsync(object id)
        {
            var entity = await Repository.GetByIdAsync(id);
            await Repository.DeleteAsync(entity);
        }

        public async virtual Task<IEnumerable<TResponseDto>> GetAllAsync<TResponseDto>()
        {
            var entities = await Repository.Queryable.ProjectTo<TResponseDto>(_mapper.ConfigurationProvider).ToListAsync();
            return entities;
        }

        public async virtual Task<TResponseDto> GetByIdAsync<TResponseDto>(object id)
        {
            var entity = await Repository.GetByIdAsync(id);
            return _mapper.Map<TResponseDto>(entity);
        }
    }
}
