using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Whats_Cookin.Server.Models
{
    public class Food_Items
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FoodName { get; set; }

        [Required, MaxLength(50)]
        public string FoodCategory { get; set; } // Example: "Fast Food", "Dessert", "Beverage"

        [Required,
            Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        [Required]
        public int RestaurantId { get; set; } // Foreign Key to Restaurant

        // Navigation Properties
        [ForeignKey("RestaurantId")]
        public Restaurants? Restaurant { get; set; }

        public ICollection<Ratings>? Ratings { get; set; }
        public ICollection<Likes>? Likes { get; set; }
    }
}
