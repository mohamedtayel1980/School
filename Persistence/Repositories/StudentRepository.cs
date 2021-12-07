using Contracts;
using Domain.Entities;
using Domain.Repositories;

using Persistence.RepositorisOpitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilities.Sorting;
using Utilities.Paging;

namespace Persistence.Repositories
{
    internal sealed class StudentRepository : RepositoryBase<Student>,
        IStudentRepository
    {
        private readonly ISortHelper<Student> _sortHelper;

        public StudentRepository(RepositoryContext repositoryContext, 
            ISortHelper<Student> sortHelper)
             : base(repositoryContext)
        {
            _sortHelper = sortHelper;
        }

        public IEnumerable<Student> GetStudentsPaged(StudentParametersPaging studentParametersPaging)
        {
            IQueryable<Student> students = FindByCondition(o => o.Age >= studentParametersPaging.MinAge &&
                              o.Age <= studentParametersPaging.MaxAge)
                             .OrderBy(on => on.Name);
            SearchByName(ref students, studentParametersPaging.Name);
            var sortedStudents = _sortHelper.ApplySort(students, studentParametersPaging.OrderBy);
            return PagedList<Student>.ToPagedList(sortedStudents,
                studentParametersPaging.PageNumber,
                studentParametersPaging.PageSize);
            //return FindAll()
            //      .OrderBy(on => on.Name)
            //      .Skip((studentPaging.PageNumber - 1) * studentPaging.PageSize)
            //      .Take(studentPaging.PageSize)
            //      .ToList();
        }
        private void SearchByName(ref IQueryable<Student> students, string studentName)
        {
            if (!students.Any() || string.IsNullOrWhiteSpace(studentName))
                return;
            students = students.Where(o => o.Name.ToLower().Contains(studentName.Trim().ToLower()));
        }
    }
}
