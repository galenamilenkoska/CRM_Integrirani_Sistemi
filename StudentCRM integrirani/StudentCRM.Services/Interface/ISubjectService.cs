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
        void UpdateExistingSubject(int id, String code, String subjectName);
        void DeleteSubject(int id);

        
    }
}
