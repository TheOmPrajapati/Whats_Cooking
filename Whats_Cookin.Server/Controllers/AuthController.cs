using Microsoft.AspNetCore.Mvc;
using Whats_Cookin.Server.Models;
using Whats_Cookin.Server.ViewModel;

namespace Whats_Cookin.Server.Controllers
{
    [Route("auth/")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ServerContext _db;
        public AuthController(ServerContext db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public IActionResult Register(Users obj)
        {
            if (obj != null && obj.Password.Length < 8) {
                ModelState.AddModelError("Password","Password length too short");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return Ok("Created user");
            }
            return BadRequest(ModelState["errors"]);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel obj)
        {
            if (obj != null)
            {
                Users? check = _db.Users.FirstOrDefault(x => x.Email.Contains(obj.Email));
                if (check != null)
                {
                    if (check.Password == obj.Password)
                    {
                        return Ok("Login successfull");
                    }
                }
                return Unauthorized();
            }
            return BadRequest(ModelState["errors"]);
        }
    }
}
