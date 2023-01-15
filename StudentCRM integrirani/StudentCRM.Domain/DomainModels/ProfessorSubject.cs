using StudentCRM.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM.Domain.DomainModels
{
    public class ProfessorSubject : BaseEntity
    {
        public long professorSubjectId { get; set; }
        public ProfessorUser professor { get; set; }
        public Subject subject { get; set; }
        public StudentSubject studentSubject { get; set; }
    }
}
