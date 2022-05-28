using University.Entities;

namespace University.Persistent.IRepositories
{
    public interface IStudentRepository : IRepository<Student,Guid>
    {
    }
}
