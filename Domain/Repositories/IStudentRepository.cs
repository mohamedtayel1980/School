
using Domain.Entities;
using Domain.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Paging;

namespace Domain.Repositories
{
   public interface IStudentRepository : IRepositoryBase<Student>
    {
        PagedList<ShapedEntity> GetStudentsPaged(StudentParametersPaging studentPaging);
        ShapedEntity GetStudentById(Guid studentId, string fields);
    }
}
