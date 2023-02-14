using StudentCRM.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM.Domain.DomainModels
{
    public class Message : BaseEntity
    {
        public string sender { get; set; }
        public string recipients { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public Student student { get; set; }
        public ProfessorUser professor { get; set; }
    }
}
