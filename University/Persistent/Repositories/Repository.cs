using Marten;
using System.Linq.Expressions;
using University.Persistent.IRepositories;

namespace University.Persistent.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {
        private readonly IDocumentSession _session;

        public Repository(IDocumentSession session)
        {
            _session = session;
        }



        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _session.Store(entity);
            }, cancellationToken);
        }

        public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            _session.Delete(entity);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                _session.Update(entity);
            }, cancellationToken);
        }


        public async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken)
        {
            switch (id.GetType().Name)
            {
                case "Guid":
                    {
                        var guid = (Guid)Convert.ChangeType(id, typeof(TKey));
                        return await _session.LoadAsync<TEntity>(guid, cancellationToken);
                    }
            }

            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entity = await _session.Query<TEntity>().ToListAsync(cancellationToken);
            return entity;
        }

        public async Task<IReadOnlyList<TEntity>> Where(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _session.Query<TEntity>().Where(predicate).ToListAsync(cancellationToken);
            return entity;
        }

      


    }
}
