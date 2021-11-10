using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;

namespace Services
{
    internal sealed class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public StudentService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public StudentDto Create(StudentDtoForCreation studentForCreationDto)
        {
            var student = _mapper.Map<Student>(studentForCreationDto);
            _repositoryManager.StudentRepository.Create(student);
            _repositoryManager.UnitOfWork.SaveChanges();
            var studentdto = _mapper.Map<StudentDto>(student);
            return studentdto;
        }

        public void Delete(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentDto> GetAll()
        {
            var students = _repositoryManager.StudentRepository.FindAll();
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentsDto;
        }

        public StudentDto GetById(Guid studentId)
        {
            throw new NotImplementedException();
        }

       

        public void Update(Guid studentId, StudentDtoForUpdate student)
        {
            throw new NotImplementedException();
        }
    }
}
