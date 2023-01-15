using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM.Domain.DomainModels
{
    public class Student : BaseEntity
    {
        public long index { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
    }
}
