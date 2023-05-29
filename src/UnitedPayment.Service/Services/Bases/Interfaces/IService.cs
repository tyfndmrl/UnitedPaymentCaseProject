namespace UnitedPayment.Service.Services.Bases.Interfaces
{
    public interface IService
    {
        Task<TResponseDto> AddAsync<TRequestDto, TResponseDto>(TRequestDto model) where TRequestDto : class, new();
        Task DeleteAsync(object id);
        Task<TResponseDto> GetByIdAsync<TResponseDto>(object id);
        Task<IEnumerable<TResponseDto>> GetAllAsync<TResponseDto>();
        Task<TResponseDto> UpdateAsync<TRequestDto, TResponseDto>(object id, TRequestDto model) where TRequestDto : class, new();
    }
}
