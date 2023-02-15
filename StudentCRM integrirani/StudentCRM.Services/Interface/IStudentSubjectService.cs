using StudentCRM.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Services.Interface
{
    public interface IStudentSubjectService
    {
        List<StudentSubject> ListAll();
        StudentSubject FindById(int? id);
        StudentSubject Create(int studentId, int subjectId);
        StudentSubject Update(int id, int studentId, int subjectId);
        StudentSubject Delete(int id);
    }
}
