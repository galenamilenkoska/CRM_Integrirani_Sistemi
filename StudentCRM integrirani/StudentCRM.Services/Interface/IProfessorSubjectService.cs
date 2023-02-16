using StudentCRM.Domain.DomainModels;
using StudentCRM.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Services.Interface
{
    public interface IProfessorSubjectService
    {
        List<ProfessorSubject> ListAll();
        ProfessorSubject FindById(int id);

        ProfessorSubject Create(int professorId, int subjectId, int studentSubjectId);

        ProfessorSubject Update(int id, int professorId, int subjectId, int studentSubjectId);

        ProfessorSubject Delete(int id);

        List<ProfessorSubject> FindAllByProf(ProfessorUser professor);

        ProfessorSubject FindByProfessorAndSubject(ProfessorUser professor, Subject subject);

        List<ProfessorSubject> FindAllByProfessorAndSubject(ProfessorUser professor, Subject subject);
        List<Subject> getLoggedProfSubjects(ProfessorUser professor);
    }
}
