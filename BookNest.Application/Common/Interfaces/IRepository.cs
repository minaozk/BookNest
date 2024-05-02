using System.Linq.Expressions;

namespace BookNest.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? IncludeProperties = null);

        T Get(Expression<Func<T, bool>>? predicate, string? IncludeProperties = null);
        void Add(T entity);
        bool Any(Expression<Func<T, bool>>? predicate);
        void Remove(T entity);

    }
}
