using StudentCRM.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCRM.Services.Interface
{
    public interface INoteService
    {
        public List<Note> ListAll();
        public Note FindById(int? id);
        public void CreateNewNote(Note n);
        public void UpdateExistingNote(Note n);
        public void DeleteNote(int id);
        public Note FindByEmail(string email);
        public List<Note> FindByStudentAndProfessor(int studentId, int professorId);
    }
}
