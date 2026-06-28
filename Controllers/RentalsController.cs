using CarRentalAPI.DTOs;
using CarRentalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalsController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rentals = await _rentalService.GetAllRentalsAsync();
        return Ok(rentals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var rental = await _rentalService.GetRentalByIdAsync(id);
        if (rental == null) return NotFound();
        return Ok(rental);
    }

    [HttpGet("{id}/details")]
    public async Task<IActionResult> GetWithDetails(int id)
    {
        var rental = await _rentalService.GetRentalWithDetailsAsync(id);
        if (rental == null) return NotFound();
        return Ok(rental);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetByCustomer(int customerId)
    {
        var rentals = await _rentalService.GetRentalsByCustomerAsync(customerId);
        return Ok(rentals);
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var rentals = await _rentalService.GetActiveRentalsAsync();
        return Ok(rentals);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRentalDto dto)
    {
        var id = await _rentalService.CreateRentalAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRentalDto dto)
    {
        var result = await _rentalService.UpdateRentalAsync(id, dto);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _rentalService.DeleteRentalAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}