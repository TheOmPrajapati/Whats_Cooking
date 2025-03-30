using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
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


        private static bool isValidPinCode(string str)
        {
            string strRegex = @"^[1-9]{1}[0-9]{2}\s{0,1}[0-9]{3}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(str))
                return (true);
            else
                return (false);
        }
        [HttpPost("register")]
        [Authorize(Roles = "RestaurantOwner")]
        public IActionResult Register(Restaurants obj)
        {
            if (obj != null)
            {
                if (!isValidPinCode(obj.Pincode.ToString().Trim()))
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
        [Authorize(Roles = "Customer")]
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
