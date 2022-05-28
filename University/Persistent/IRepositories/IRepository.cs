using System.Linq.Expressions;

namespace University.Persistent.IRepositories
{
    public interface IRepository<TEntity, in TKey> : IDisposable where TEntity : class 
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<TEntity>> Where(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);

        Task CommitChanges(CancellationToken cancellationToken = default);
    }
}
