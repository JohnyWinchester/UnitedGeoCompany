namespace UnitedGeoCompany.Repository.Interfaces;

/// <summary>
/// Управление данными
/// </summary>
/// <typeparam name="T">Тип данных</typeparam>
public interface IRepository<T> : IReadOnlyRepository<T>
    where T : class
{
    /// <summary>
    /// Adds entity of type T and save changes into database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task AddAsync(T entity);

    /// <summary>
    /// Adds entities of type T and save changes into database.
    /// </summary>
    /// <param name="entities"></param>
    Task AddRangeAsync(T[] entities);

    /// <summary>
    /// Update entity of type T and save changes into database
    /// </summary>
    /// <param name="entity"></param>
    Task Update(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Include entity
    /// </summary>
    /// <param name="entity"></param>
    void Include<TEntity>(TEntity entity)
        where TEntity : class;

    /// <summary>
    /// Remove entity of type T and save changes into database
    /// </summary>
    /// <param name="entity"></param>
    Task Remove(T entity);

    /// <summary>
    /// Remove entities of type T and save changes into database.
    /// </summary>
    /// <param name="entities"></param>
    Task RemoveRange(T[] entities);
    Task UpdateRange(ICollection<T> entities, CancellationToken cancellationToken);
}
