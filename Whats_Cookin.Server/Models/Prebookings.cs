using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Whats_Cookin.Server.Models
{
    public class Prebookings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [Required, MaxLength(50)]
        public string TransactionId { get; set; } // Unique transaction reference

        [Required]
        public DateTime BookingTime { get; set; }

        // Navigation Properties
        [ForeignKey("UserId")]
        public Users User { get; set; }
    }
}
