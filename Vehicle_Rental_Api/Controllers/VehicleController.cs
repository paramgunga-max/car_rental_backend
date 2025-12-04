using Microsoft.AspNetCore.Mvc;
using Vehicle_Rental.Core.DTO;
using Vehicle_Rental_Api.Services;

namespace Vehicle_Rental_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetAll()
        {
            var vehicles = await _service.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetById(int id)
        {
            var vehicle = await _service.GetVehicleByIdAsync(id);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] VehicleDto dto)
        {
            await _service.AddVehicleAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.CarId }, dto);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] VehicleDto dto)
        {
            if (id != dto.CarId)
                return BadRequest("ID mismatch");

            await _service.UpdateVehicleAsync(dto);
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteVehicleAsync(id);
            return NoContent();
        }
    }
}
