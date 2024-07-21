using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitectureData.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mail Adresi Zorunludur")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur")]
        public string? Password { get; set; }
    }
}
