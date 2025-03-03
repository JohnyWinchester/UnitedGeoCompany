using System.Linq.Expressions;

namespace UnitedGeoCompany.Repository.Interfaces;

public interface IReadOnlyRepository<T> where T : class
{
    Task<TResult> MaxAsync<TResult>(Expression<Func<T, TResult>> expression, CancellationToken cancellationToken = default);

    Task<TResult> MaxAsync<TResult>(Expression<Func<T, bool>> predicat, Expression<Func<T, TResult>> expression, CancellationToken cancellationToken = default);

    Task<bool> ContainsAsync(Expression<Func<T, bool>> predicat, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<T, bool>> value, CancellationToken cancellationToken = default);

    /// <summary>
    ///
    /// </summary>
    /// <param name="predicate">Filters</param>
    /// <param name="include">Example: t => t.Property1, p => p.Property2</param>
    /// <returns>Return an object of type T</returns>
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<T, object?>>[] include);

    /// <summary>
    ///
    /// </summary>
    /// <param name="predicate">Filter</param>
    /// <param name="take">сколько взять</param>
    /// <param name="include">Example: t => t.Property1, p => p.Property2</param>
    /// <returns>Return a list of objects of type T</returns>
    Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>> predicate,
        int? take,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object?>>[] include);
}