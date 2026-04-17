using System.ComponentModel.DataAnnotations;

namespace ResortBookingAPI.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public long UserId { get; set; }

        public User? User { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
