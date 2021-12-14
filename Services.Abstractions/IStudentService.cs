using Contracts;
using Utilities.Paging;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Abstractions
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetAll();
        IEnumerable<StudentDto> MapShapedStudentsTOStudentDto(List<BaseEntity> students);
        PagedList<StudentDto> GetAllPaging(StudentParametersPaging studentPaging);

        StudentDto GetById(Guid studentId);
        StudentDto GetById(Guid studentId, string fields);
        StudentDto Create(StudentDtoForCreation studentForCreationDto);

        void Update(Guid studentId, StudentDtoForUpdate student);

        void Delete(Guid studentId);
    }

}
