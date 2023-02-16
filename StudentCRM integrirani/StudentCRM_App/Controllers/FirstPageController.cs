using Microsoft.AspNetCore.Mvc;
using StudentCRM.Domain.DomainModels;
using StudentCRM.Domain.Identity;
using StudentCRM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM_App.Controllers
{
    [ApiController]
    [Route("api/first")]
    public class FirstPageController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IUserService _userService;
        private readonly INoteService _noteService;
        private readonly IProfessorSubjectService _professorSubjectService;
        private readonly IStudentSubjectService _studentSubjectService;

        public FirstPageController(IStudentService studentService, ISubjectService subjectService, IUserService userService, INoteService noteService, IProfessorSubjectService professorSubjectService, IStudentSubjectService studentSubjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _userService = userService;
            _noteService = noteService;
            _professorSubjectService = professorSubjectService;
            _studentSubjectService = studentSubjectService;
        }

        [HttpPost("listSubjects")]
        public IActionResult ListMySubjects(int professorId)
        {
            ProfessorUser professor = _userService.FindById(professorId);
            List<Subject> subjects = _professorSubjectService.getLoggedProfSubjects(professor);
            return Ok(subjects);
        }

        [HttpPost("viewStudents")]
        public IActionResult ViewStudents(int subjectId, int professorId)
        {
            Subject subject = _subjectService.FindById(subjectId);
            ProfessorUser professor = _userService.FindById(professorId);
            List<ProfessorSubject> profSubjStudents = _professorSubjectService.FindAllByProfessorAndSubject(professor, subject);
            return Ok(profSubjStudents);
        }

        /*public IActionResult ViewStudentDetails(int studentId, int professorId)
        {
            List<Note> notes = this._noteService.FindByStudentAndProfessor(studentId, professorId);

            return Ok(notes);
        }*/

        //GET: api/note
       [HttpGet("notes")]
        public IActionResult GetAllNotes()
        {
            var notes = _noteService.ListAll();
            if (notes == null && notes.Count == 0)
                return NoContent();

            return Ok(notes);
        }

        // GET: api/note/5
        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            var note = _noteService.FindById(id);
            if (note == null)
                return NotFound();

            return Ok(note);
        }

        // POST: api/note
        [HttpPost("{note}")]
        public IActionResult CreateNewNote([FromBody] Note note)
        {
            if (note == null)
                return BadRequest();

            _noteService.CreateNewNote(note);

            return CreatedAtRoute(nameof(GetNoteById), new { id = note.Id }, note);
        }

        // PUT: api/note/5
        [HttpPut("{id}")]
        public IActionResult UpdateNoteById(int id, [FromBody] Note note)
        {
            if (note == null && note.Id != id)
                return BadRequest();

            var existingNote = _noteService.FindById(id);
            if (existingNote == null)
                return NotFound();

            existingNote.text = note.text;
            existingNote.date = note.date;
            existingNote.isActive = note.isActive;
            existingNote.student = note.student;
            existingNote.professor = note.professor;

            _noteService.UpdateExistingNote(existingNote);

            return NoContent();
        }

        // DELETE: api/note/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNoteById(int id)
        {
            var existingNote = _noteService.FindById(id);
            if (existingNote == null)
                return NotFound();

            _noteService.DeleteNote(id);

            return NoContent();
        }
    }
}
