using Microsoft.AspNetCore.Mvc;
using StudentCRM.Domain.DomainModels;
using StudentCRM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM_App.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public IActionResult GetAllSubjects()
        {
            var subjects = _subjectService.ListAll();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubject(int id)
        {
            var subject = _subjectService.FindById(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        public IActionResult CreateSubject([FromBody] Subject subject)
        {
            _subjectService.CreateNewSubject(subject);
            return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, subject);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id, [FromBody] Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            _subjectService.UpdateExistingSubject(subject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _subjectService.FindById(id);
            if (subject == null)
            {
                return NotFound();
            }

            _subjectService.DeleteSubject(id);
            return NoContent();
        }
    }
}
