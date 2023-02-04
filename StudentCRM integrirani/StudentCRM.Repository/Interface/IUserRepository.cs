using StudentCRM.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ProfessorUser> GetAll();
        ProfessorUser Get(int id);
        void Insert(ProfessorUser entity);
        void Update(ProfessorUser entity);
        void Delete(ProfessorUser entity);
    }
}
