using System.Linq.Expressions;
using Hid.CheckPoint.Shared.Domain;
using Hid.CheckPoint.Shared.PaginationResult;
using Hid.Checkpoint.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

public class BaseRepositoryIdentity<TContext, TEntity, TId> : BaseRepository<TContext, TEntity>,
    IBaseRepositoryIdentity<TEntity, TId>
    where TEntity : BaseEntity<TId>, new()
    where TContext : DbContext
{
    protected BaseRepositoryIdentity(TContext context) : base(context)
    {
    }

    public virtual Task<TEntity?> GetByIdAsync(
        TId id,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include)
        => GetItemAsync(q => q.Id!.Equals(id), cancellationToken, include);
}

public abstract class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
    where TEntity : class, new()
    where TContext : DbContext
{
    protected TContext Context { get; }

    protected BaseRepository(TContext context)
    {
        Context = context;
    }

    /// <inheritdoc />
    public IQueryable<TEntity> AsQueryable()
    {
        return Context.Set<TEntity>();
    }

    /// <inheritdoc />
    public virtual async Task<PaginationResult<TEntity>> GetPagedAsync(
        Expression<Func<TEntity, bool>> predicate,
        IEnumerable<OrderByPropertyDescriptor<TEntity>>? orderByProperties = null,
        int? take = null,
        int? skip = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include)
    {
        var itemsSet = await Get(
                predicate: predicate,
                orderByProperties: orderByProperties,
                take: take,
                skip: skip,
                include: include)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync(cancellationToken);

        var total = await CountAsync(predicate, cancellationToken);

        return PaginationResult<TEntity>.Ok(
            itemsSet,
            pageSize: take ?? 0,
            pageNumber: PageCalculateHelper.CalculatePageNumber(take, skip),
            total);
    }

    /// <inheritdoc />
    public virtual async Task<PaginationResult<TSelector>> GetSelectorPagedAsync<TSelector>(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TSelector>> selector,
        IEnumerable<OrderByPropertyDescriptor<TEntity>>? orderByProperties = null,
        int? take = null, int? skip = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include)
    {
        var itemsSet = await Get(
                predicate: predicate,
                orderByProperties: orderByProperties,
                take: take,
                skip: skip,
                include: include)
            .AsNoTrackingWithIdentityResolution()
            .Select(selector)
            .ToListAsync(cancellationToken);

        var total = await CountAsync(predicate, cancellationToken);

        return PaginationResult<TSelector>.Ok(
            itemsSet,
            pageSize: take ?? 0,
            pageNumber: PageCalculateHelper.CalculatePageNumber(take, skip),
            total);
    }

    /// <inheritdoc />
    public virtual IQueryable<TEntity> GetQuery(
        Expression<Func<TEntity, bool>> predicate,
        IEnumerable<OrderByPropertyDescriptor<TEntity>>? orderByProperties = null,
        bool orderByDescending = true,
        params Expression<Func<TEntity, object>>[]? include)
    {
        var query = Get(
            predicate,
            orderByProperties,
            include: include);

        return query;
    }

    /// <inheritdoc />
    public virtual async Task<TEntity?> GetItemAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include)
    {
        var query = Get(
            predicate: predicate,
            include: include);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc />
    public virtual async Task<TSelector?> GetItemSelectorAsync<TSelector>(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TSelector>> selector,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? include)
    {
        var query = Get(
                predicate: predicate,
                include: include)
            .Select(selector);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc />
    public virtual void Add(TEntity entity) => Context.Set<TEntity>().Add(entity);

    /// <inheritdoc />
    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Context.Set<TEntity>().Add(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public virtual Task AddRange(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        => Context.Set<TEntity>().AddRangeAsync(entity, cancellationToken);

    /// <inheritdoc />
    public virtual void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    /// <inheritdoc />
    public virtual void RemoveRange(IEnumerable<TEntity> entity) =>
        Context.Set<TEntity>().RemoveRange(entity);

    /// <inheritdoc />
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => Context.SaveChangesAsync(cancellationToken);

    /// <inheritdoc />
    public virtual Task<int> CountAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
        => Context.Set<TEntity>().CountAsync(predicate, cancellationToken);

    /// <inheritdoc />
    public virtual Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
        => Context.Set<TEntity>().AnyAsync(predicate, cancellationToken);

    protected virtual IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>> predicate,
        IEnumerable<OrderByPropertyDescriptor<TEntity>>? orderByProperties = null,
        int? take = null,
        int? skip = null,
        params Expression<Func<TEntity, object>>[]? include)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        query = query.Where(predicate);

        var orderByPropertiesArray = orderByProperties?.ToArray();
        if (orderByPropertiesArray?.Any() == true)
        {
            var isFirstOrdering = true;

            IOrderedQueryable<TEntity> orderedQuery = null!;

            foreach (var descriptor in orderByPropertiesArray)
            {
                if (isFirstOrdering)
                {
                    orderedQuery = descriptor.Direction == EnumSortDirection.Asc
                        ? query.OrderBy(descriptor.Expression)
                        : query.OrderByDescending(descriptor.Expression);

                    isFirstOrdering = false;
                }
                else
                {
                    orderedQuery = descriptor.Direction == EnumSortDirection.Asc
                        ? orderedQuery.ThenBy(descriptor.Expression)
                        : orderedQuery.ThenByDescending(descriptor.Expression);
                }
            }

            query = isFirstOrdering ? query : orderedQuery;
        }

        query = skip.HasValue ? query.Skip(skip.Value) : query;
        query = take.HasValue ? query.Take(take.Value) : query;

        return query;
    }
}
