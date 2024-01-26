using System.Linq.Expressions;
using helppeople.BolsaEmpleo.Domain.Common;

namespace helppeople.BolsaEmpleo.Domain.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> Save(TEntity entity);

    Task Save(ICollection<TEntity> entities);

    Task<TEntity?> FindById(int id, params Expression<Func<TEntity, object>>[]? includes);

    Task<TEntity?> FindOne(Expression<Func<TEntity, bool>> predicate);
    
    Task<IList<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

    Task<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[]? includes);

    Task<TEntity> Update(TEntity entity);

    Task DeleteById(int id);

    Task Delete(TEntity entity);
}