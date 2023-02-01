using StudentCRM.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Services.Interface
{
    public interface IStudentService
    {
        List<Student> ListAll();
        Student FindById(int? id);
        void CreateNewStudent(Student s);
        void UpdateExistingStudent(Student s);
        void DeleteStudent(int id);
        Student FindByEmail(string email);
    }
}
