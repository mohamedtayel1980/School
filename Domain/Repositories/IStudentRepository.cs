
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Paging;

namespace Domain.Repositories
{
   public interface IStudentRepository : IRepositoryBase<Student>
    {
        IEnumerable<Student> GetStudentsPaged(StudentParametersPaging studentPaging);
    }
}
