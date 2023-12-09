namespace JobTracking.Data.Abstract;

public interface IGenericRepository<T>
    where T : class, IBaseEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null);

    Task<int> CountAsync();
    Task<bool> AnyAsync();

    Task<T> AddAsync(T entity);
    T Update(T entity);
}