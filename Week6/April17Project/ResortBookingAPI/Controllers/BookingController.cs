using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResortBookingAPI.Data;
using ResortBookingAPI.Models;

namespace ResortBookingAPI.Controllers
{
    [ApiController]
    [Route("api/booking")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var bookings = _context.Bookings
                .Include(x => x.User)
                .Include(x => x.Resort)
                .ToList();

            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(long id)
        {
            var booking = _context.Bookings
                .Include(x => x.User)
                .Include(x => x.Resort)
                .FirstOrDefault(x => x.BookingId == id);

            if (booking == null)
                return NotFound("Booking not found");

            return Ok(booking);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetBookingsByUserId(long userId)
        {
            var bookings = _context.Bookings
                .Include(x => x.Resort)
                .Where(x => x.UserId == userId)
                .ToList();

            return Ok(bookings);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            // default status
            booking.Status = "Pending";

            // calculate days
            int days = (booking.ToDate - booking.FromDate).Days;

            if (days <= 0)
                days = 1;

            var resort = _context.Resorts.Find(booking.ResortId);

            if (resort == null)
                return NotFound("Resort not found");

            booking.TotalPrice = days * resort.Price * booking.NoOfPersons;

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return StatusCode(201, booking);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateBooking(long id, Booking updatedBooking)
        {
            var booking = _context.Bookings.Find(id);

            if (booking == null)
                return NotFound("Booking not found");

            booking.Status = updatedBooking.Status;

            _context.SaveChanges();

            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(long id)
        {
            var booking = _context.Bookings.Find(id);

            if (booking == null)
                return NotFound("Booking not found");

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return Ok("Booking cancelled successfully");
        }
    }
}