using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitectureData.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? GsmNo { get; set; }
        public string? ForgotPasswordGuid { get; set; }
        public int CompanyId { get; set; }
    }
}
