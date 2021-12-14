using Contracts;
using Utilities.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Services.Abstractions;
using System;
using System.Text.Json;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using Utilities.APILinks;
using Domain.Helpers;
using Domain.Entities;

namespace Presentation.Controllers
{

    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private LinkGenerator _linkGenerator;
        public StudentController(IServiceManager serviceManager, LinkGenerator linkGenerator)
        {
            _serviceManager = serviceManager;
            _linkGenerator = linkGenerator;
        }

        //public string Get()
        //{
        //    return "Hello";
        //}
        //public IActionResult GetStudents()
        //{
        //    var studentsDto = _serviceManager.StudentService.GetAll();

        //    return Ok(studentsDto);
        //}
        public IActionResult GetStudentsPaged([FromQuery] StudentParametersPaging studentPaging)
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
            var shapedStudents = students.Select(o => o.Entity).ToList(); ;

            var mediaType = (MediaTypeHeaderValue)HttpContext.Items["AcceptHeaderMediaType"];

            if (!mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase))
            {
                return Ok(shapedStudents);
            }

            for (var index = 0; index < students.Count(); index++)
            {
                var studentLinks = CreateLinksForStudents(students[index].Id
                    , studentPaging.Fields); ;
                shapedStudents[index].Add("Links", studentLinks);
            }

            var studentWrapper = new LinkCollectionWrapper<StudentDto>(_serviceManager.StudentService.
                MapShapedStudentsTOStudentDto(shapedStudents).ToList());

            return Ok(CreateLinksForStudents(studentWrapper));
            //return Ok(students);
        }

        private object CreateLinksForStudents(Guid id, string fields)
        {
            var links = new List<Link>
    {
        new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetStudentById), values: new { id, fields }),
        "self",
        "GET"),
        new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(DeleteStudent), values: new { id }),
        "delete_Student",
        "DELETE"),
        new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(UpdateStudent), values: new { id }),
        "update_stduent",
        "PUT")
    };
            return links;
        }
        private LinkCollectionWrapper<StudentDto> CreateLinksForStudents(LinkCollectionWrapper<StudentDto> studentWrapper)
        {
            studentWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetStudentsPaged), values: new { }),
                    "self",
                    "GET"));
            return studentWrapper;
        }
        private IEnumerable<Link> CreateLinksForStudent(Guid id, string fields = "")
        {


            throw new Exception();
        }

        
        [Route("AddStudent")]
        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDtoForCreation student)
        {
            //if (student == null)            
            //    throw new StudentCreationBadRequest("Student object sent from client is null.");          

            if (!ModelState.IsValid) return BadRequest("student data is incorrect ");
            var studentDto = _serviceManager.StudentService.Create(student);
            return CreatedAtRoute("StudentById", new { id = studentDto.Id }, studentDto);
        }
        [Route("InfoStudentUpdate")]
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Guid id, [FromBody] StudentDtoForUpdate student)
        {


            if (!ModelState.IsValid) return BadRequest("Student object sent from client is incorrect.");

            _serviceManager.StudentService.Update(id, student);
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
        public IActionResult GetStudentById(Guid id,string fields)
        {
            var studentDto = _serviceManager.StudentService.GetById(id, fields);

            var mediaType = (MediaTypeHeaderValue)HttpContext.Items["AcceptHeaderMediaType"];

            if (!mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase))
            {
              
                return Ok(studentDto.Entity);
            }

            studentDto.Entity.Add("Links", CreateLinksForStudent(studentDto.Id, fields));

            return Ok(studentDto.Entity);
        }


    }
}
