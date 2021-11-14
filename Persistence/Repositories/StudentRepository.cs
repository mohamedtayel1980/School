using Contracts;
using Domain.Entities;
using Domain.Repositories;
using CrossCutting.Paging;
using Persistence.RepositorisOpitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class StudentRepository : RepositoryBase<Student>,
        IStudentRepository,
        IstudentOpitions
    {
        public StudentRepository(RepositoryContext repositoryContext)
             : base(repositoryContext)
        {
        }

        public IEnumerable<Student> GetStudentsPaged(StudentPaging studentPaging)
        {
            return FindAll()
                  .OrderBy(on => on.Name)
                  .Skip((studentPaging.PageNumber - 1) * studentPaging.PageSize)
                  .Take(studentPaging.PageSize)
                  .ToList();
        }
    }
}
