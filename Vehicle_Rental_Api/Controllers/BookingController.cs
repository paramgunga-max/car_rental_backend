using Microsoft.AspNetCore.Mvc;
using Vehicle_Rental.Core.DTO;
using Vehicle_Rental_Api.Services;

namespace Vehicle_Rental_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAll()
        {
            var bookings = await _service.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // GET:
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetById(int id)
        {
            var booking = await _service.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        // POST: 
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BookingDto dto)
        {
            await _service.AddBookingAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.BookingID }, dto);
        }

        // PUT: 
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BookingDto dto)
        {
            if (id != dto.BookingID)
                return BadRequest("ID mismatch");

            await _service.UpdateBookingAsync(dto);
            return NoContent();
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}
