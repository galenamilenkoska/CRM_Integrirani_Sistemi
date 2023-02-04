using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentCRM.Domain;
using StudentCRM.Domain.DomainModels;
using StudentCRM.Domain.Identity;
using System;

namespace StudentCRM.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ProfessorUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();


            //builder.Entity<Message>()
            //    .Property(z => z.messageId)
            //    .ValueGeneratedOnAdd();



            builder.Entity<Note>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Subject>()
               .Property(z => z.Id)
               .ValueGeneratedOnAdd();

            builder.Entity<StudentSubject>()
              .Property(z => z.Id)
              .ValueGeneratedOnAdd();

            builder.Entity<ProfessorSubject>()
              .Property(z => z.Id)
              .ValueGeneratedOnAdd();
        }
    }
}
