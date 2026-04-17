using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResortBookingAPI.Data;
using ResortBookingAPI.Models;

namespace ResortBookingAPI.Controllers
{
    [ApiController]
    [Route("api/resort")]
    [Authorize]
    public class ResortController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResortController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllResorts()
        {
            var resorts = _context.Resorts.ToList();
            return Ok(resorts);
        }

        [HttpGet("{id}")]
        public IActionResult GetResortById(long id)
        {
            var resort = _context.Resorts.Find(id);

            if (resort == null)
                return NotFound("Resort not found");

            return Ok(resort);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddResort(Resort resort)
        {
            _context.Resorts.Add(resort);
            _context.SaveChanges();

            return StatusCode(201, resort);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateResort(long id, Resort updatedResort)
        {
            var resort = _context.Resorts.Find(id);

            if (resort == null)
                return NotFound("Resort not found");

            resort.ResortName = updatedResort.ResortName;
            resort.ResortImageUrl = updatedResort.ResortImageUrl;
            resort.ResortLocation = updatedResort.ResortLocation;
            resort.ResortAvailableStatus = updatedResort.ResortAvailableStatus;
            resort.Price = updatedResort.Price;
            resort.Capacity = updatedResort.Capacity;
            resort.Description = updatedResort.Description;

            _context.SaveChanges();

            return Ok(resort);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteResort(long id)
        {
            var resort = _context.Resorts.Find(id);

            if (resort == null)
                return NotFound("Resort not found");

            _context.Resorts.Remove(resort);
            _context.SaveChanges();

            return Ok("Resort deleted successfully");
        }
    }
}