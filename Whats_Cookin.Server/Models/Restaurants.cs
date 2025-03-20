using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whats_Cookin.Server.Models
{
    public class Restaurants
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string ShopNo { get; set; }

        [MaxLength(100)]
        public string BuildingName { get; set; }

        [Required, MaxLength(100)]
        public string Landmark { get; set; }

        [Required, MaxLength(6)]
        public int Pincode { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(3)]
        public int Capacity { get; set; }

        public int CurrentOccupancy { get; set;}

        // Navigation Properties
        [ForeignKey("OwnerId")]
        public Users Owner { get; set; }

        public ICollection<Food_Items>? FoodItems { get; set; }
        public ICollection<Ratings>? Ratings { get; set; }
        public ICollection<Prebookings>? Prebookings { get; set; }

    }
}
