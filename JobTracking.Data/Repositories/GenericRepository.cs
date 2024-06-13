namespace JobTracking.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class, IBaseEntity, new()
{
    protected readonly DatabaseContext _context;

    public GenericRepository(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = _context.Set<T>().AsNoTracking();
        query = ApplyPredicate(query, predicate);
        return await query.AnyAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = _context.Set<T>().AsNoTracking();
        query = ApplyPredicate(query, predicate);
        return await query.CountAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>? orderBy = null)
    {
        IQueryable<T> query = _context.Set<T>().AsNoTracking();
        query = ApplyPredicate(query, predicate);
        if (orderBy != null)
            query = query.OrderBy(orderBy);
        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = _context.Set<T>().AsNoTracking();
        query = ApplyPredicate(query, predicate);
        return await query.SingleOrDefaultAsync();
    }

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }

    public async Task<T?> GetByIdAsync(object id)
        => await _context.Set<T>().FindAsync(id);

    private IQueryable<T> ApplyPredicate(IQueryable<T> query, Expression<Func<T, bool>> predicate)
       => predicate != null ? query.Where(predicate) : query;
}