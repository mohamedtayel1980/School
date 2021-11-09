using Contracts;
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
        public IActionResult CreateStudent([FromBody] StudentDto studentDto)
        {
            var studentsDto = _serviceManager.StudentService.Create(studentDto);
            return Ok(studentsDto);
        }
    }
}
