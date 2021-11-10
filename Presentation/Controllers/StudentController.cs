﻿using Contracts;
using Domain.Exceptions;
using Domain.Exceptions.StudentExceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public StudentController(IServiceManager serviceManager) => _serviceManager = serviceManager;
        public IActionResult GetStudents()
        {
            var studentsDto = _serviceManager.StudentService.GetAll();

            return Ok(studentsDto);
        }
        [Route("AddStudent")]
        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDtoForCreation student)
        {
            if (student == null)            
                throw new StudentCreationBadRequest("Student object sent from client is null.");          

            if (!ModelState.IsValid) throw new StudentCreationBadRequest("Student object sent from client is incorrect.");
            var studentDto = _serviceManager.StudentService.Create(student);
            return CreatedAtRoute("StudentById", new { id = studentDto.StudentId }, studentDto);
        }
        [Route("StudentById")]
        [HttpGet("{ownerId:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var studentDto =  _serviceManager.StudentService.GetById(id);

            return Ok(studentDto);
        }
    }
}
