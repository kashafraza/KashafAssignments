using System.ComponentModel.DataAnnotations;

namespace ResortBookingAPI.Models
{
    public class ErrorLog
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
