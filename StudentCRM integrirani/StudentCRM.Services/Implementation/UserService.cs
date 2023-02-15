using StudentCRM.Domain.Identity;
using StudentCRM.Repository.Interface;
using StudentCRM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCRM.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<ProfessorUser> ListAll()
        {
            return this.userRepository.GetAll().ToList();
        }

        public ProfessorUser FindById(int id)
        {
            return this.userRepository.Get(id);
        }

        public void CreateNewUser(ProfessorUser user)
        {
            this.userRepository.Insert(user);
        }

        public void UpdateExistingUser(ProfessorUser user)
        {
            this.userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = this.FindById(id);
            this.userRepository.Delete(user);
        }
    }
}
