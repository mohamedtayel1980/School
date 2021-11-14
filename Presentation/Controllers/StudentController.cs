using Contracts;
using CrossCutting.Paging;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Text.Json;

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
        public IActionResult GetStudentsPaged([FromQuery] StudentPaging studentPaging)
        {
            var students = _serviceManager.StudentService.GetAllPaging(studentPaging);
            var metadata = new
            {
                students.TotalCount,
                students.PageSize,
                students.CurrentPage,
                students.TotalPages,
                students.HasNext,
                students.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(students);
        }
        [Route("AddStudent")]
        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDtoForCreation student)
        {
            //if (student == null)            
            //    throw new StudentCreationBadRequest("Student object sent from client is null.");          

            if (!ModelState.IsValid) return BadRequest("student data is incorrect ");
            var studentDto = _serviceManager.StudentService.Create(student);
            return CreatedAtRoute("StudentById", new { id = studentDto.StudentId }, studentDto);
        }
        [Route("InfoStudentUpdate")]
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Guid id, [FromBody] StudentDtoForUpdate student)
        {
        

            if (!ModelState.IsValid) return BadRequest("Student object sent from client is incorrect.");

            _serviceManager.StudentService.Update(id,student);
            return CreatedAtRoute("StudentById", new { id = id });
        }
        [Route("StudentRemove")]
        [HttpPut("{id}")]
        public IActionResult DeleteStudent(Guid id)
        {


            if (!ModelState.IsValid) return BadRequest("Student object sent from client is incorrect.");

            _serviceManager.StudentService.Delete(id);
            return NoContent();
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
