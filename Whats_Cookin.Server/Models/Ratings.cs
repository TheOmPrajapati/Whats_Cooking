using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Whats_Cookin.Server.Models
{
    public class Ratings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } // Foreign Key to User

        [Required]
        public int RestaurantId { get; set; } // Foreign Key to Restaurant

        public int? FoodId { get; set; } // Foreign Key to FoodItem (Nullable)

        [Required]
        [Range(1, 5)]
        public int RatingValue { get; set; } // Rating between 1-5 stars

        [MaxLength(500)]
        public string? ReviewComment { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Default to current date

        // Navigation Properties
        [ForeignKey("UserId")]
        public Users? User { get; set; }
    }
}
