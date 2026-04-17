using Microsoft.EntityFrameworkCore;
using ResortBookingAPI.Models;

namespace ResortBookingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
