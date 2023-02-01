using StudentCRM.Domain.DomainModels;
using StudentCRM.Repository.Interface;
using StudentCRM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StudentCRM.Services.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> subjectRepository;
        
        public SubjectService(IRepository<Subject> subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        public List<Subject> ListAll()
        {
            return this.subjectRepository.GetAll().ToList();
        }

        public Subject FindById(Guid? id)
        {
            return this.subjectRepository.Get(id);
        }

        public void CreateNewSubject(Subject s)
        {
            this.subjectRepository.Insert(s);
        }
        
        public void UpdateExistingSubject(Subject s)
        {
            this.subjectRepository.Update(s);
        }

        public void DeleteSubject(Guid id)
        {
            var subject = this.FindById(id);
            this.subjectRepository.Delete(subject);
        }

        public void UpdateExistingSubject(Guid id, string code, string subjectName)
        {
            throw new NotImplementedException();
        }
    }
}
