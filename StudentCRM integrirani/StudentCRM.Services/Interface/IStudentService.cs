using StudentCRM.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Services.Interface
{
    public interface IStudentService
    {
        List<Student> ListAll();
        Student FindById(Guid? id);
        void CreateNewStudent(Student s);
        void UpdateExistingStudent(Student s);
        void DeleteStudent(Guid id);
        Student FindByEmail(string email);
    }
}
