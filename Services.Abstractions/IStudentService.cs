using Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetAll();

       StudentDto GetById(Guid studentId);

        StudentDtoForCreation Create(StudentDtoForCreation studentForCreationDto);

        void Update(Guid studentId, StudentDto studentForUpdateDto);

        void Delete(Guid studentId);
    }

}
