﻿using Microsoft.EntityFrameworkCore;
using StudentCRM.Domain.DomainModels;
using StudentCRM.Domain.Identity;
using StudentCRM.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace StudentCRM.Repository.Implementation
{
    public class CustomRepository : ICustomRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ICustomRepository customRepository;

        public CustomRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ProfessorSubject> FindAllByProfessor(ProfessorUser professor)
        {
            return context.Set<ProfessorSubject>()
                .Where(ps => ps.professor.Id == professor.Id)
                .ToList();
        }

        public ProfessorSubject FindByProfessorAndSubject(ProfessorUser professor, Subject subject)
        {
            return context.Set<ProfessorSubject>()
                .FirstOrDefault(ps => ps.professor.Id == professor.Id && ps.subject.Id == subject.Id);
        }

        public List<ProfessorSubject> FindAllByProfessorAndSubject(ProfessorUser professor, Subject subject)
        {
            return context.Set<ProfessorSubject>()
                .Where(ps => ps.professor.Id == professor.Id && ps.subject.Id == subject.Id)
                .ToList();
        }

        //za notes
        public List<Note> FindByStudentAndProfessor(int studentId, int professorId)
        {
            return context.Set<Note>().Where(n => n.student.Id == studentId && n.professor.Id == professorId).ToList();
        }
        public ProfessorUser FindByUsername(String username)
        {
            return customRepository.FindByUsername(username);
            

        }
    }
}

