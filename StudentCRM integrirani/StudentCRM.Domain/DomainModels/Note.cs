using StudentCRM.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM.Domain.DomainModels
{
    public class Note : BaseEntity
    {
        public string text { get; set; }
        public DateTime date { get; set; }
        public bool isActive { get; set; }
        public Student student { get; set; }
        public ProfessorUser professor { get; set; }
    }
}
