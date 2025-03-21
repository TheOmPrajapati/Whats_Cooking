using System.ComponentModel.DataAnnotations;

namespace Whats_Cookin.Server.ViewModel
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
