using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierArchitectureData.Auth;

namespace NTierArchitectureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new Exception("Kullanıcı daha önceden tanımlanmış");

            ApplicationUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                //NormalizedEmail = _userManager.NormalizeEmail( model.Email),
                UserName = model.Username,
                //NormalizedUserName = _userManager.NormalizeName( model.Username),
                Name = model.Name,
                Surname = model.SurName,
                CompanyId = 1,
                EmailConfirmed = true
            };

                var result = await _userManager.CreateAsync(user, model.Password);
            //    if (!result.Succeeded)
            //    {
            //        throw new Exception("Kullanıcı oluşturulamadı! Bilgileri kontrol edip tekrar deneyiniz..");
            //        _logger.LogError("Bilgiler Yanlış Kullanıcı Oluşturulamadı");
            //    }

            //    if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            //        await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            //    if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            //        await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //    if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            //        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            //    if (await _roleManager.RoleExistsAsync(UserRoles.User))
            //        await _userManager.AddToRoleAsync(user, UserRoles.User);

                return Ok("Kullanıcı Oluşturuldu");
            //}
        }
    }
}
