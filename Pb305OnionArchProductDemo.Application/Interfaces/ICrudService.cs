namespace Pb305OnionArchProductDemo.Application.Interfaces;

public interface ICrudService<TDto, TCreateDto, TUpdateDto, TEntity>
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(int id);
    Task<TDto> AddAsync(TCreateDto createDto);
    Task UpdateAsync(TUpdateDto updateDto);
    Task DeleteAsync(int id);
}