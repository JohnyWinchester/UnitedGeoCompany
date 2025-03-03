namespace UnitedGeoCompany.Repository.Implementations;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnitedGeoCompany.Repository.Interfaces;

/// <inheritdoc cref="IRepository{T}"/>
public class Repository<T, TContext> : IRepository<T>
    where T : class
    where TContext : DbContext
{
    protected readonly TContext _context;

    public Repository(TContext dbContext) => _context = dbContext;

    /// <inheritdoc/>
    public virtual async Task AddAsync(T entity)
    {
        _ = await _context.Set<T>().AddAsync(entity);
        _ = await _context.SaveChangesAsync();
    }

    public virtual async Task AddRangeAsync(T[] entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        _ = await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public virtual Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int? take, CancellationToken cancellationToken = default, params Expression<Func<T, object?>>[] include)
    {
        var query = _context.Set<T>().Where(predicate);

        query = include.Aggregate(query, (current, inc) => current.Include(inc));

        if (take is not null)
            query = query.Take(take.Value);

        return query.ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default,
        params Expression<Func<T, object?>>[] include)
    {
        var query = _context.Set<T>() as IQueryable<T>;

        query = include.Aggregate(query, (current, inc) => current.Include(inc));

        return query.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    /// <inheritdoc/>
    public virtual Task Remove(T entity)
    {
        _ = _context.Set<T>().Remove(entity);
        return _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public virtual Task RemoveRange(T[] entities)
    {
        _context.Set<T>().RemoveRange(entities);
        return _context.SaveChangesAsync();
    }

    public virtual Task Update(T entity, CancellationToken cancellationToken = default)
    {
        _ = _context.Set<T>().Update(entity);
        return _context.SaveChangesAsync(cancellationToken);
    }

    public virtual Task UpdateRange(ICollection<T> entities, CancellationToken cancellationToken)
    {
        _context.Set<T>().UpdateRange(entities);
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Include<TEntity>(TEntity entity)
        where TEntity : class
        => _context.Attach(entity);

    public Task<TResult> MaxAsync<TResult>(Expression<Func<T, TResult>> expression, CancellationToken cancellationToken = default)
        => _context.Set<T>().AsNoTracking().IgnoreAutoIncludes().MaxAsync(expression, cancellationToken);

    public Task<TResult> MaxAsync<TResult>(Expression<Func<T, bool>> predicat, Expression<Func<T, TResult>> expression, CancellationToken cancellationToken = default)
        => _context.Set<T>().AsNoTracking().IgnoreAutoIncludes().Where(predicat).MaxAsync(expression, cancellationToken);

    public Task<bool> ContainsAsync(Expression<Func<T, bool>> predicat, CancellationToken cancellationToken = default)
       => _context.Set<T>()
        .AsNoTracking().IgnoreAutoIncludes()
        .AnyAsync(predicat, cancellationToken);

    public Task<int> CountAsync(Expression<Func<T, bool>> value, CancellationToken cancellationToken = default)
        => _context.Set<T>().AsNoTracking().IgnoreAutoIncludes().CountAsync(value, cancellationToken);
}
