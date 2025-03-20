using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Whats_Cookin.Server.Models
{
    public class Likes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } // Foreign Key to User

        public int? RestaurantId { get; set; } // Nullable Foreign Key

        public int? FoodId { get; set; } // Nullable Foreign Key

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Default to current date

        // Navigation Properties
        [ForeignKey("UserId")]
        public Users User { get; set; }
    }
}
