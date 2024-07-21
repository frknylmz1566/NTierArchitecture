using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitectureData.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Mail Adresi Zorunludur")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Soyisim zorunludur")]
        public string? SurName { get; set; }
    }
}
