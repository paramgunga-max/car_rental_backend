using Microsoft.AspNetCore.Mvc;
using Vehicle_Rental.Core.DTO;
using Vehicle_Rental_Api.Services;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;
    public CustomerController(ICustomerService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
    {
        var customers = await _service.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var customer = await _service.GetCustomerByIdAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CustomerDto dto)
    {
        await _service.AddCustomerAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.CustomerId }, dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] CustomerDto dto)
    {
        if (id != dto.CustomerId) return BadRequest("ID mismatch");
        await _service.UpdateCustomerAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteCustomerAsync(id);
        return NoContent();
    }
}
