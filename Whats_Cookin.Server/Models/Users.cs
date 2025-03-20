using System.ComponentModel.DataAnnotations;

namespace Whats_Cookin.Server.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, MaxLength(10)]
        public string Mobile { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required]
        public UserType User_Type { get; set; }

        // Navigation Properties
        public ICollection<Restaurants>? Restaurants { get; set; } // A user can own multiple restaurants
        public ICollection<Ratings>? Ratings { get; set; }
        public ICollection<Prebookings>? Prebookings { get; set; }
        public ICollection<Likes>? Likes { get; set; }
        public enum UserType
        {
            RestaurantOwner,
            Customer
        }
    }
}
