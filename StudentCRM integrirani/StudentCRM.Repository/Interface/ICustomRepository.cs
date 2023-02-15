using StudentCRM.Domain.DomainModels;
using StudentCRM.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Repository.Interface
{
    public interface ICustomRepository
    {
        List<ProfessorSubject> FindAllByProfessor(ProfessorUser professor);
        ProfessorSubject FindByProfessorAndSubject(ProfessorUser professor, Subject subject);
        List<ProfessorSubject> FindAllByProfessorAndSubject(ProfessorUser professor, Subject subject);
    }
}
