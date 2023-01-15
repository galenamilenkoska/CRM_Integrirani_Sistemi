using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM.Domain.DomainModels
{
    public class StudentSubject : BaseEntity
    {
        public long studentSubjectId { get; set; }
        public Student student { get; set; }
        public Subject subject { get; set; }
    }
}
