﻿using Marten;
using University.Entities;
using University.Persistent.IRepositories;

namespace University.Persistent.Repositories
{
    public class StudentRepository : Repository<Student,Guid>, IStudentRepository
    {
        public StudentRepository(IDocumentSession session) : base(session)
        {
        }
    }
}
