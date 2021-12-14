using AutoMapper;
using Contracts;
using Utilities.Paging;
using Domain.Entities;
using Domain.Exceptions.StudentExceptions;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Helpers;

namespace Services
{
    internal sealed class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IDataShaper<StudentDto> _dataShaper;

        public StudentService(IRepositoryManager repositoryManager,
            IMapper mapper,
            IDataShaper<StudentDto> dataShaper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public StudentDto Create(StudentDtoForCreation studentForCreationDto)
        {
            if (studentForCreationDto == null)
                throw new StudentCreationBadRequest("Student object sent from client is null.");
            var student = _mapper.Map<Student>(studentForCreationDto);
            _repositoryManager.StudentRepository.Create(student);
            _repositoryManager.UnitOfWork.SaveChanges();
            var studentdto = _mapper.Map<StudentDto>(student);
            return studentdto;
        }

        public void Delete(Guid studentId)
        {
            var studentEntity = _repositoryManager.StudentRepository
                .FindByCondition(s => s.Id.Equals(studentId)).FirstOrDefault();
            if (studentEntity == null) throw new StudentNotFound($"Student with Id{studentId} not found");
            _repositoryManager.StudentRepository.Delete(studentEntity);
            _repositoryManager.UnitOfWork.SaveChanges();
        }

        public IEnumerable<StudentDto> GetAll()
        {
            var students = _repositoryManager.StudentRepository.FindAll();
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentsDto;
        }

        public PagedList<StudentDto> GetAllPaging(StudentParametersPaging studentPaging)
        {
            //return GetAll()
            //      .OrderBy(sd => sd.Name)
            //      .Skip((studentPaging.PageNumber - 1) * studentPaging.PageSize)
            //      .Take(studentPaging.PageSize)
            //      .ToList(); ;
            var studentsPaged = _repositoryManager.StudentRepository.GetStudentsPaged(studentPaging);         
            
            return _mapper.Map<PagedList<StudentDto>>(studentsPaged);

        }

        
        public StudentDto GetById(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public StudentDto GetById(Guid studentId, string fields)
        {
            var student = _repositoryManager.StudentRepository.FindByCondition(student => student.Id.Equals(studentId))
                    .DefaultIfEmpty(new Student())
                    .FirstOrDefault();
           var studentDto= _mapper.Map<StudentDto>(student);
          
            var shaped= _dataShaper.ShapeData(studentDto, fields);
            return _mapper.Map<StudentDto>(shaped);
        }

        public IEnumerable<StudentDto> MapShapedStudentsTOStudentDto(List<BaseEntity> students)
        {
            var studentsDto = _mapper.Map<List<StudentDto>>(students);
            return studentsDto;
        }

        public void Update(Guid studentId, StudentDtoForUpdate student)
        {
            if (student == null)
                throw new StudentCreationBadRequest("Student object sent from client is null.");
            var studentEntity = _repositoryManager.StudentRepository
                .FindByCondition(s => s.Id.Equals(studentId)).FirstOrDefault();
            if (studentEntity == null) throw new StudentNotFound($"Student with Id{studentId} not found");
            _mapper.Map(student, studentEntity);
            _repositoryManager.StudentRepository.Update(studentEntity);
            _repositoryManager.UnitOfWork.SaveChanges();
        }
    }
}
