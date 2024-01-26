using System.Linq.Expressions;
using helppeople.BolsaEmpleo.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace helppeople.BolsaEmpleo.Domain.Common;

public abstract class BaseRepository<TEntity, TDbContext> : IRepository<TEntity>
    where TEntity : BaseEntity where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;

    protected BaseRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<TEntity> Save(TEntity entity)
    {
        var savedEntity = await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return savedEntity.Entity;
    }

    public virtual async Task Save(ICollection<TEntity> entities)
    {
        await _dbContext.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> FindById(int id, params Expression<Func<TEntity, object>>[]? includes)
    {
        if (includes.Length == 0) return await _dbContext.FindAsync<TEntity>(id);
        IQueryable<TEntity> collection = _dbContext.Set<TEntity>();
        collection = Include(collection, includes);
        return await collection.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public virtual async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> collection = _dbContext.Set<TEntity>();
        return await collection.Where(predicate).SingleOrDefaultAsync();
    }

    public virtual async Task<IList<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> collection = _dbContext.Set<TEntity>();
        return await collection.Where(predicate).ToListAsync();
    }

    public virtual async Task<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[]? includes)
    {
        IQueryable<TEntity> collection = _dbContext.Set<TEntity>();
        collection = Include(collection, includes);
        return await collection.ToListAsync();
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        return await Task.Run(async () =>
        {
            var updatedEntity = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return updatedEntity.Entity;
        });
    }

    public virtual async Task DeleteById(int id)
    {
        var entity = await _dbContext.FindAsync<TEntity>(id);
        await Delete(entity);
    }

    public virtual async Task Delete(TEntity entity)
    {
        await Task.Run(async () =>
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        });
    }

    private static IQueryable<TEntity> Include(IQueryable<TEntity> collection,
        params Expression<Func<TEntity, object>>[]? includes)
    {
        if (includes == null || includes.Length == 0) return collection;
        return includes.Aggregate(collection, (entities, expression) => entities.Include(expression));
    }
}