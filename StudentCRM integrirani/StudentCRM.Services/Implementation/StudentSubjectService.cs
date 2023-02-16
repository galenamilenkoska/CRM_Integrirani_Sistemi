using StudentCRM.Domain.DomainModels;
using StudentCRM.Repository.Interface;
using StudentCRM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StudentCRM.Services.Implementation
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly IRepository<StudentSubject> studentSubjectRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Subject> subjectRepository;

        public StudentSubjectService(IRepository<StudentSubject> studentSubjectRepository, IRepository<Student> studentRepository, IRepository<Subject> subjectRepository)
        {
            this.studentSubjectRepository = studentSubjectRepository;
            this.studentRepository = studentRepository;
            this.subjectRepository = subjectRepository;
        }

        public StudentSubject Create(int studentId, int subjectId)
        {
            Student student = this.studentRepository.Get(studentId);
            Subject subject = this.subjectRepository.Get(subjectId);
            StudentSubject studentSubject = new StudentSubject();
            studentSubject.student=student;
            studentSubject.subject=subject;
            this.studentSubjectRepository.Insert(studentSubject);
            return studentSubject;
        }

        public StudentSubject Delete(int id)
        {
            StudentSubject studentSubject = this.FindById(id);
            this.studentSubjectRepository.Delete(studentSubject);
            return studentSubject;
        }

        public StudentSubject FindById(int? id)
        {
            return this.studentSubjectRepository.Get(id);
        }

        public List<StudentSubject> ListAll()
        {
            return this.studentSubjectRepository.GetAll().ToList();

        }


        public StudentSubject Update(int id, int studentId, int subjectId)
        {
            StudentSubject studentSubject = this.FindById(id);
            Student student = this.studentRepository.Get(studentId);
            Subject subject = this.subjectRepository.Get(subjectId);
            studentSubject.student = student;
            studentSubject.subject = subject;
            this.studentSubjectRepository.Insert(studentSubject);
            return studentSubject;
        }

    }
}
