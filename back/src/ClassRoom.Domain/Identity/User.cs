using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ClassRoom.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string ImagemURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}