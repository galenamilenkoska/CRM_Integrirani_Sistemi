using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM.Domain.DomainModels
{
    public class Subject : BaseEntity
    {

        public string code { get; set; }

        public string subjectName { get; set; }
    }
}
