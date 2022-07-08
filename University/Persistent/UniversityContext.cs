using Microsoft.EntityFrameworkCore;
using University.Entities;

namespace University.Persistent
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }
    }
}
