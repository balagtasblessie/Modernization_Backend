using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using ClockDB.Models;
using ClockDB.Manager;
using Microsoft.Extensions.Configuration;
using ClockDB.Data;
using ClockDB.Validator;

namespace ClockDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginValidator _validator;
        private readonly ClockDBContext _context;
        private readonly LoginManager _loginManager;
        private readonly IConfiguration _configuration;

        public LoginController(ClockDBContext context, IConfiguration configuration)
        {
            _context = context;
            _validator = new LoginValidator();
            _loginManager = new LoginManager(context);
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] userLogin request)
        {
            if (!_validator.isValid(request))
            {
                return BadRequest("Invalid credentials");
            }

            UserTable user = _loginManager.getUser(request.UserName, request.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            if (key.Length < 32)
            {
                throw new ArgumentOutOfRangeException("JWT key must be at least 32 characters long.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.RoleDescription)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString, FullName = user.FullName, UserId = user.id, RoleDescription = user.RoleDescription });
        }
    }
}
