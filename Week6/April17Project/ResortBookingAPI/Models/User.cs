using System.ComponentModel.DataAnnotations;
namespace ResortBookingAPI.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required]
        public string UserRole { get; set; }   // Admin / Customer
    }
}
