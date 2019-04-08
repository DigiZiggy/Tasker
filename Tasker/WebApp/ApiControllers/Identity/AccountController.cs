using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApp.ApiControllers.Identity
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(SignInManager<AppUser> signInManager, IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody]LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {

                var appUser = await _userManager.FindByEmailAsync(model.Email);
                var claims = await _userManager.GetClaimsAsync(appUser);
                
                var jwt = JwtHelper.GenerateJwt(
                    claims,
                    _configuration["JWT:Key"], 
                    _configuration["JWT:Issuer"],
                    int.Parse(_configuration["JWT:ExpireDays"]));
                
                return Ok(jwt);
            }

            return StatusCode(403);
        }
        
        [HttpPost]
        public async Task<string> Register([FromBody]RegisterDTO model)
        {
            return "foo";
        }

        public class LoginDTO
        {
            public string Email { get; set; }
            public string Password { get; set; }
            
        }
        
        public class RegisterDTO
        {
            public string Email { get; set; }
            
            [Required]
            [MinLength(6)]
            public string Password { get; set; }
            
        }
        
    }
}