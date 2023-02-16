using StudentCRM.Domain.DomainModels;
using StudentCRM.Domain.Identity;
using StudentCRM.Repository.Interface;
using StudentCRM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCRM.Services.Implementation
{
    public class ProfessorSubjectService : IProfessorSubjectService
    {
        private readonly IRepository<ProfessorSubject> repository;
        private readonly IStudentSubjectService studentSubjectService;
        private readonly ISubjectService subjectService;
        private readonly IUserService professorService;
        private readonly ICustomRepository customRepository;

        public ProfessorSubjectService(IRepository<ProfessorSubject> repository)
        {
            this.repository = repository;
        }

        public ProfessorSubject Create(int professorId, int subjectId, int studentSubjectId)
        {
            StudentSubject studentSubject = this.studentSubjectService.FindById(studentSubjectId);
            Subject subject = this.subjectService.FindById(subjectId);
            ProfessorUser professor = this.professorService.FindById(professorId);
            ProfessorSubject professorSubject = new ProfessorSubject();
            professorSubject.professor = professor;
            professorSubject.subject = subject;
            professorSubject.studentSubject = studentSubject;
            this.repository.Insert(professorSubject);
            return professorSubject;
        }

        public ProfessorSubject Delete(int id)
        {
            ProfessorSubject professorSubject = this.FindById(id);
            this.repository.Delete(professorSubject);
            return professorSubject;
        }

        public List<ProfessorSubject> FindAllByProf(ProfessorUser professor)
        {
            return this.customRepository.FindAllByProfessor(professor);

        }

        public List<ProfessorSubject> FindAllByProfessorAndSubject(ProfessorUser professor, Subject subject)
        {
            return this.customRepository.FindAllByProfessorAndSubject(professor, subject);
        }

        public ProfessorSubject FindById(int id)
        {
            return this.repository.Get(id);
        }

        public ProfessorSubject FindByProfessorAndSubject(ProfessorUser professor, Subject subject)
        {
            return this.customRepository.FindByProfessorAndSubject(professor, subject);
        }

        public List<ProfessorSubject> ListAll()
        {
            return repository.GetAll().ToList();
        }

        public ProfessorSubject Update(int id, int professorId, int subjectId, int studentSubjectId)
        {
            ProfessorSubject professorSubject = this.FindById(id);
            StudentSubject studentSubject = this.studentSubjectService.FindById(studentSubjectId);
            Subject subject = this.subjectService.FindById(subjectId);
            ProfessorUser professor = this.professorService.FindById(professorId);
            professorSubject.professor = professor;
            professorSubject.subject = subject;
            professorSubject.studentSubject = studentSubject;
            this.repository.Insert(professorSubject);
            return professorSubject;
        }

        public List<Subject> getLoggedProfSubjects(ProfessorUser professor)
        {
            List<Subject> subjects = new List<Subject>();
            var professorSubjects = customRepository.FindAllByProfessor(professor);

            foreach (var professorSubject in professorSubjects)
            {
                subjects.Add(professorSubject.subject);
            }

            return subjects.Distinct().ToList();
        }
    }
}
