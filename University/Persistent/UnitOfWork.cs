using Marten;
using University.Persistent.IRepositories;
using University.Persistent.Repositories;

namespace University.Persistent
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly IDocumentSession _session;
        private bool _disposed;
        public UnitOfWork(IDocumentStore store)
        {
            _session = store.LightweightSession();
            StudentRepository = new StudentRepository(_session);
        }

        public IStudentRepository StudentRepository { get; }


        public async Task CommitChanges(CancellationToken cancellationToken = default)
        {
            await _session.SaveChangesAsync(cancellationToken);
        }

      

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _session.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
