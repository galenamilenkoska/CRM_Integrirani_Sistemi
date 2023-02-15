using StudentCRM.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Services.Interface
{
    public interface ISubjectService
    {
        List<Subject> ListAll();
        Subject FindById(int? id);
        void CreateNewSubject(Subject s);
        void UpdateExistingSubject(Subject subject);
        void DeleteSubject(int id);
        void UpdateExistingSubject(int id, string code, string subjectName);

    }
}
