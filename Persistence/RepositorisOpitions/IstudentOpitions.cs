using Contracts;
using Utilities.Paging;
using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositorisOpitions
{
    public interface IstudentOpitions
    {
        IEnumerable<Student> GetStudentsPaged(StudentParametersPaging studentPaging);
    }
}
