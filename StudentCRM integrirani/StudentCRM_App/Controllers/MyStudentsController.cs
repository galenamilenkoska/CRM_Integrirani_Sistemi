using Microsoft.AspNetCore.Mvc;
using StudentCRM.Domain.Identity;
using StudentCRM.Repository.Interface;
using StudentCRM.Services.Interface;
using System;

namespace StudentCRM_App.Controllers
{
    [ApiController]
    [Route("api/mystudents")]
    public class MyStudentsController : Controller
    {
        private readonly IStudentService myStudentService;
        private readonly ICustomRepository customRepository;
        private readonly INoteService notesService;
        //private readonly IMessagesService messagesService;

        public MyStudentsController(IStudentService studentService)
        {
            myStudentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ShowMyStudents(String username)
        {
            var loggedProf = this.customRepository.FindByUsername(username);
            // var subjects = this.subjectService.ListAll();
            // var myStudents = new List<ProfessorSubject>();
            // ProfessorSubject profSubjStudent;
            //
            // for (var i = 0; i < subjects.Count; i++)
            // {
            //     profSubjStudent = this.professorSubjectService.FindByProfessorAndSubject(loggedProf, subjects[i]);
            //     myStudents.Add(profSubjStudent);
            // }
            //
            // ViewData["MyStudents"] = myStudents;

            // var profSubjStudents = this.professorSubjectService.FindAllByProfessorAndSubject(loggedProf, subject);
            // var myStudents = new List<Student>();
            //
            // foreach (var profSubjStudent in profSubjStudents)
            // {
            //     myStudents.Add(profSubjStudent.Student);
            // }
            //
            // ViewData["MyStudents"] = myStudents;

            ViewData["LoggedProf"] = loggedProf;
            ViewData["BodyContent"] = "myStudents";
            return View("master-template");
        }

        [HttpGet("viewNotes/{studentId}")]
        public IActionResult ViewNotes(int studentId,String username)
        {
            var loggedProf = this.customRepository.FindByUsername(username);
            var student = this.myStudentService.FindById(studentId);
            //var notes = this.notesService.FindByStudentAndProfessor(studentId, loggedProf);

            ViewData["BodyContent"] = "notes";
            //ViewData["Notes"] = notes;
            ViewData["LoggedProf"] = loggedProf;
            ViewData["Student"] = student;
            return View("master-template");
        }

        [HttpGet("viewMessages/{studentId}")]
        public IActionResult ViewMessages(int studentId,String username)
        {
            var loggedProf = this.customRepository.FindByUsername(username);
            var student = this.myStudentService.FindById(studentId);
            //this.messagesService.GetInbox(loggedProf);
            //var messages = this.messagesService.FindAllByStudent(studentId);

            ViewData["BodyContent"] = "mail";
            //ViewData["Messages"] = messages;
            ViewData["LoggedProf"] = loggedProf;
            ViewData["Student"] = student;
            return View("master-template");
        }




    }
}
