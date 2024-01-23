using System.Linq.Expressions;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contrats.Persistence;

public interface IAsyncRepository<T> where T : BasicDomainModel
{
    Task<IReadOnlyList<T>> GetAllAsync();
    
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeString = null,
        bool disabledTraking = false);
    
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<Expression<Func<T, object>>> includes = null,
        bool disabledTraking = false);

    Task<T> GetById(int id);

    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}