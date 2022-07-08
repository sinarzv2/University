using University.Persistent.IRepositories;

namespace University.Persistent
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }

        Task CommitChanges(CancellationToken cancellationToken = default);
    }
}
