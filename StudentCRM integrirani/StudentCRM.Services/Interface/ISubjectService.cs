using StudentCRM.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Services.Interface
{
    public interface ISubjectService
    {
        List<Subject> ListAll();
        Subject FindById(Guid? id);
        void CreateNewSubject(Subject s);
        void UpdateExistingSubject(Guid id, String code, String subjectName);
        void DeleteSubject(Guid id);

        
    }
}
