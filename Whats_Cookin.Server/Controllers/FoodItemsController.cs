using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Whats_Cookin.Server.Models;

namespace Whats_Cookin.Server.Controllers
{
    [Route("fooditems/")]
    [ApiController]
    public class FoodItemsController : Controller
    {
        private readonly ServerContext _db;

        public FoodItemsController(ServerContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var itemslist = _db.Food_Items.ToList();

            return Ok(itemslist);
        }

        [HttpPost("register")]
        public IActionResult Register(Food_Items obj)
        {
            if (obj != null && obj.Price.Equals(0))
            {
                ModelState.AddModelError("Price", "Price cannot be zero");
            }
            if(ModelState.IsValid)
            {
                _db.Food_Items.Add(obj);
                _db.SaveChanges();
                return Ok("Food item successfully registered");
            }
            return BadRequest(ModelState["errors"]);
        }
    }
}
