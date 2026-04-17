using System.ComponentModel.DataAnnotations;

namespace ResortBookingAPI.Models
{
    public class Booking
    {
        [Key]
        public long BookingId { get; set; }

        [Required]
        public int NoOfPersons { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Status { get; set; }

        // Foreign Key - User
        public long UserId { get; set; }
        public User? User { get; set; }

        // Foreign Key - Resort
        public long ResortId { get; set; }
        public Resort? Resort { get; set; }
    }
}
