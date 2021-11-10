using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.StudentExceptions
{
    public sealed class StudentCreationBadRequest : BadRequestException
    {
        public StudentCreationBadRequest(string message) : base(message)
        {
        }
    }
}
