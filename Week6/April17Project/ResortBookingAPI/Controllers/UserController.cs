using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ResortBookingAPI.Data;
using ResortBookingAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ResortBookingAPI.DTOs;


namespace ResortBookingAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public UserController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(x => x.Email == user.Email))
            {
                return BadRequest("Email already exists");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return StatusCode(201, user);
        }

        
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginUser)
        {
            var user = _context.Users.FirstOrDefault(x =>
                x.Email == loginUser.Email &&
                x.Password == loginUser.Password);

            if (user == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            string token = GenerateToken(user);

            return Ok(new
            {
                token = token,
                userId = user.UserId,
                username = user.Username,
                role = user.UserRole
            });
        }

        
        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole),
                new Claim("UserId", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}