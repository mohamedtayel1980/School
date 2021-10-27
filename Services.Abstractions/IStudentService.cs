using Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<StudentDto> GetByIdAsync(Guid studentId, CancellationToken cancellationToken = default);

        Task<StudentDto> CreateAsync(StudentDto studentForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid studentId, StudentDto studentForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid studentId, CancellationToken cancellationToken = default);
    }

}
