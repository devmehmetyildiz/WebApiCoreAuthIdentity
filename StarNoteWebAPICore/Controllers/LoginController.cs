using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StarNoteWebAPICore.DataAccess;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace StarNoteWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ILogger<LoginController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public LoginController(IConfiguration config,ILogger<LoginController> logger, StarNoteEntity context)
        {
            _config = config;
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserCredential userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }

        private string Generate(UsersModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Kullanıcıadi),
                new Claim(ClaimTypes.Email, user.Mailadres),
                new Claim(ClaimTypes.Name, user.İsim),
                new Claim(ClaimTypes.Surname, user.Soyisim),
                new Claim(ClaimTypes.Role, user.Yetki)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
             _config["Jwt:Audience"],
             claims,
             expires: DateTime.Now.AddMinutes(3),
             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UsersModel Authenticate(UserCredential userLogin)
        {         
            var currentUser = unitOfWork.UserRepository.Finduser(userLogin.UserName, userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}
