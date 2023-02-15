using StudentCRM.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Services.Interface
{
    public interface IUserService
    {
        public List<ProfessorUser> ListAll();
        public ProfessorUser FindById(int id);
        public void CreateNewUser(ProfessorUser user);
        public void UpdateExistingUser(ProfessorUser user);
        public void DeleteUser(int id);
    }
}
