using Microsoft.AspNetCore.Mvc;
using Whats_Cookin.Server.Models;

namespace Whats_Cookin.Server.Controllers
{
    [Route("restaurants/")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly ServerContext _db;
        public RestaurantController(ServerContext db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public IActionResult Register(Restaurants obj)
        {
            if (obj != null)
            {
                if (obj.Pincode.ToString().Length != 6)
                {
                    ModelState.AddModelError("Pincode", "Invalid Pincode");
                }
                else if (obj.Capacity.Equals(0))
                {
                    ModelState.AddModelError("Capacity", "Enter valid capacity");
                }
            }
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(obj);
                _db.SaveChanges();
                return Ok("Restaurant registered successfully");
            }
            return BadRequest(ModelState["errors"]);
        }

        public class RestaurantDto
        {
            public string Name { get; set; }
            public string Landmark { get; set; }
            public string City { get; set; }
        }

        [HttpGet]
        public IActionResult Index()
        {
            var restaurants = _db.Restaurants.Select(
                x => new RestaurantDto
                {
                    Name = x.Name,
                    Landmark = x.Landmark,
                    City = x.City
                }
            ).ToList();
            return Ok(restaurants);
        }
    }
}
