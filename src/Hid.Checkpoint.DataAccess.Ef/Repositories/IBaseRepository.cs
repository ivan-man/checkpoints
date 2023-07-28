using System.Linq.Expressions;
using Hid.CheckPoint.Shared.Domain;
using Hid.CheckPoint.Shared.PaginationResult;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories;

public interface IBaseRepositoryIdentity<TEntity, TId> : IBaseRepository<TEntity> where TEntity : BaseEntity<TId>
{
    Task<TEntity?> GetByIdAsync(
        TId id,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include);
}

public interface IBaseRepository<TEntity>
{
    /// <summary>
    /// Full query
    /// </summary>
    IQueryable<TEntity> AsQueryable();

    /// <summary>
    /// Get paged result query.
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <param name="orderByProperties">Set of sorting descriptors</param>
    /// <param name="cancellationToken"></param>
    /// <param name="include">Set of include expressions</param>
    /// <returns></returns>
    Task<PaginationResult<TEntity>> GetPagedAsync(
        Expression<Func<TEntity, bool>> predicate,
        IEnumerable<OrderByPropertyDescriptor<TEntity>>? orderByProperties = null,
        int? take = null,
        int? skip = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include);

    /// <summary>
    /// Get paged result query with selector.
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <param name="selector">Selector</param>
    /// <param name="orderByProperties">Set of sorting descriptors</param>
    /// <param name="cancellationToken"></param>
    /// <param name="include">Set of include expressions</param>
    /// <returns></returns>
    Task<PaginationResult<TSelector>> GetSelectorPagedAsync<TSelector>(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TSelector>> selector,
        IEnumerable<OrderByPropertyDescriptor<TEntity>>? orderByProperties = null,
        int? take = null,
        int? skip = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include);

    /// <summary>
    /// Get customized query.
    /// </summary>
    /// <param name="predicate">Predicate for data set</param>
    /// <param name="orderByProperties">Ordering expressions</param>
    /// <param name="orderByDescending">Ordering desc flag</param>
    /// <param name="include">List of properties to include</param>
    /// <returns>Query</returns>
    IQueryable<TEntity> GetQuery(
        Expression<Func<TEntity, bool>> predicate,
        IEnumerable<OrderByPropertyDescriptor<TEntity>>? orderByProperties = null,
        bool orderByDescending = true,
        params Expression<Func<TEntity, object>>[]? include);

    /// <summary>
    /// Get item.
    /// </summary>
    /// <param name="predicate">Predicate for data set</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <param name="include">List of properties to include</param>
    /// <returns>Entity</returns>
    Task<TEntity?> GetItemAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include);

    /// <summary>
    /// Get item with Selector.
    /// </summary>
    /// <param name="predicate">Predicate for data set</param>
    /// <param name="selector">Properties to get expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <param name="include">List of properties to include</param>
    /// <returns>Entity</returns>
    Task<TSelector?> GetItemSelectorAsync<TSelector>(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TSelector>> selector,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include);

    /// <summary>
    /// Add new entity
    /// </summary>
    /// <param name="entity">Entity to add</param>
    void Add(TEntity entity);

    /// <summary>
    /// Add entity and save it. 
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <param name="cancellationToken"></param>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add list of entities
    /// </summary>
    Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove entity
    /// </summary>
    void Remove(TEntity entity);

    /// <summary>
    /// Remove entity
    /// </summary>
    void RemoveRange(IEnumerable<TEntity> entities);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get number of items by predicate
    /// </summary>
    /// <param name="predicate">Predicate expression</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Number of items</returns>
    Task<int> CountAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Check of existing any entity by predicate
    /// </summary>
    /// <returns></returns>
    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
}
