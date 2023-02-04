using Microsoft.EntityFrameworkCore;
using StudentCRM.Domain.Identity;
using StudentCRM.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCRM.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ProfessorUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ProfessorUser>();
        }

        public IEnumerable<ProfessorUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public ProfessorUser Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(ProfessorUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ProfessorUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(ProfessorUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
