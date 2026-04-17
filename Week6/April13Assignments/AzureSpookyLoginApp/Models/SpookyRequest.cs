using System.ComponentModel.DataAnnotations;

namespace AzureSpookyLoginApp.Models
{
    public class SpookyRequest
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
    }
}
