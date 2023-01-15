using StudentCRM.Domain.DomainModels;
using StudentCRM.Repository.Interface;
using StudentCRM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCRM.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> studentRepository;
        
        public StudentService(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public List<Student> ListAll()
        {
            return this.studentRepository.GetAll().ToList();
        }

        public Student FindById(Guid? id)
        {
            return this.studentRepository.Get(id);
        }

        public void CreateNewStudent(Student s)
        {
            this.studentRepository.Insert(s);
        }
        
        public void UpdateExistingStudent(Student s)
        {
            this.studentRepository.Update(s);
        }

        public void DeleteStudent(Guid id)
        {
            var student = this.FindById(id);
            this.studentRepository.Delete(student);
        }

        public Student FindByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
