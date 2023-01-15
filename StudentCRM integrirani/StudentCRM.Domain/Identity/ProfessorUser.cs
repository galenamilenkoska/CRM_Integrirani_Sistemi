using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRM.Domain.Identity
{
    public class ProfessorUser : IdentityUser
    {
        public long professorId { get; set; }

        //public string username { get; set; }

        //public String password;
        public string name { get; set; }
        public string surname { get; set; }

        //public String password2;
    }
}
