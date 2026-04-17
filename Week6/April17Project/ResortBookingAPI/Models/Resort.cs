using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ResortBookingAPI.Models
{
    public class Resort
    {
        [Key]
        public long ResortId { get; set; }

        [Required]
        public string ResortName { get; set; }

        [Required]
        public string ResortImageUrl { get; set; }

        [Required]
        public string ResortLocation { get; set; }

        [Required]
        public string ResortAvailableStatus { get; set; }

        [Required]
        public long Price { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
