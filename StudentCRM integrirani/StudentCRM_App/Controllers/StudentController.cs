using Microsoft.AspNetCore.Mvc;
using StudentCRM.Domain.DomainModels;
using StudentCRM.Services.Implementation;
using StudentCRM.Services.Interface;

namespace StudentCRM_App.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.ListAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.FindById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _studentService.CreateNewStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _studentService.UpdateExistingStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.FindById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
