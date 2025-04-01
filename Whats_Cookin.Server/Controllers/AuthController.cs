using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Whats_Cookin.Server.Models;
using Whats_Cookin.Server.ViewModel;

namespace Whats_Cookin.Server.Controllers
{

    [Route("auth/")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ServerContext _db;
        private readonly IConfiguration _config;
        public AuthController(ServerContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
    
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(Users obj)
        {
            if (obj != null && obj.Password.Length < 8) {
                ModelState.AddModelError("Password","Password length too short");
            }
            if (ModelState.IsValid)
            {
                var existingUser = _db.Users
                .FirstOrDefault(u => u.Email == obj.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email is already taken.");

                }
                else
                {
                    _db.Users.Add(obj);
                    _db.SaveChanges();
                    return Ok("Created user");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginModel obj)
        {
            if (obj != null)
            {
                Users? check = _db.Users.FirstOrDefault(x => x.Email.Contains(obj.Email));
                if (check != null)
                {
                    if (check.Password == obj.Password)
                    {
                        var tokenstr = GenerateJsonWebToken(check);
                        return Ok(tokenstr);
                    }
                }
                return Unauthorized();
            }
            return BadRequest(ModelState["errors"]);
        }
        private string GenerateJsonWebToken(Users user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub,user.Name),
                new Claim(ClaimTypes.Role,user.User_Type.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"],claims,
                expires:DateTime.Now.AddMinutes(60),signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
