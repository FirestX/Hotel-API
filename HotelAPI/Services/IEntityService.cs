namespace HotelAPI.Services;

public interface IEntityService<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task DeleteAsync(T entity);
}
