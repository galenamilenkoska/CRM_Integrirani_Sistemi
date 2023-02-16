using StudentCRM.Domain.DomainModels;
using StudentCRM.Domain.Identity;
using StudentCRM.Repository.Interface;
using StudentCRM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCRM.Services.Implementation
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> noteRepository;
        private readonly ICustomRepository customRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
            this.noteRepository = noteRepository;
        }
        public List<Note> ListAll()
        {
            return this.noteRepository.GetAll().ToList();
        }

        public Note FindById(int? id)
        {
            return this.noteRepository.Get(id);
        }

        public void CreateNewNote(Note n)
        {
            this.noteRepository.Insert(n);
        }

        public void UpdateExistingNote(Note n)
        {
            this.noteRepository.Update(n);
        }

        public void DeleteNote(int id)
        {
            var note = this.FindById(id);
            this.noteRepository.Delete(note);
        }

        public Note FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<Note> FindByStudentAndProfessor(int studentId, int professorId)
        {
            return this.customRepository.FindByStudentAndProfessor(studentId, professorId);
        }
    }
}
