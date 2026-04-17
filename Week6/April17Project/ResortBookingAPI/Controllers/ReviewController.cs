using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResortBookingAPI.Data;
using ResortBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ResortBookingAPI.Controllers
{
    [ApiController]
    [Route("api/review")]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        // ======================================
        // GET ALL REVIEWS (ADMIN ONLY)
        // GET: /api/review
        // ======================================
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var reviews = _context.Reviews
                .Include(x => x.User)
                .ToList();

            return Ok(reviews);
        }

        // ======================================
        // GET REVIEWS BY USER ID
        // GET: /api/review/2
        // ======================================
        [HttpGet("{userId}")]
        public IActionResult GetReviewsByUserId(long userId)
        {
            var reviews = _context.Reviews
                .Where(x => x.UserId == userId)
                .ToList();

            return Ok(reviews);
        }

        // ======================================
        // ADD REVIEW (CUSTOMER ONLY)
        // POST: /api/review
        // ======================================
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            if (review.Rating < 1 || review.Rating > 5)
            {
                return BadRequest("Rating must be between 1 and 5");
            }

            review.DateCreated = DateTime.Now;

            _context.Reviews.Add(review);
            _context.SaveChanges();

            return StatusCode(201, review);
        }
    }
}
