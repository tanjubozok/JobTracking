namespace JobTracking.Data.Repositories;

public class GenericRepository<T>(DatabaseContext context) : IGenericRepository<T>
    where T : class, IBaseEntity, new()
{
    protected readonly DatabaseContext _context = context;

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> AnyAsync()
        => await _context.Set<T>().AnyAsync();

    public async Task<int> CountAsync()
        => await _context.Set<T>().CountAsync();

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        => predicate == null
        ? await _context.Set<T>().AsNoTracking().ToListAsync()
        : await _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();

    public async Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null)
        => predicate == null
        ? await _context.Set<T>().FirstOrDefaultAsync()
        : await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }
}