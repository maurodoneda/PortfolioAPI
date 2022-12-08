namespace DataAccess;

public interface IBaseRepository
{
    Task<T> CreateAsync<T>(T entity) where T : class;
    Task<T> ReadAsync<T>(int id) where T : class;
    Task<T> UpdateAsync<T>(T entity) where T : class;
    Task DeleteAsync<T>(T entity) where T : class;
}