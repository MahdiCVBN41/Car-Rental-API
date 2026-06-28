using CarRentalAPI.DTOs;
using CarRentalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _carService.GetAllCarsAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var car = await _carService.GetCarByIdAsync(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable()
    {
        var cars = await _carService.GetAvailableCarsAsync();
        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarDto dto)
    {
        var id = await _carService.CreateCarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCarDto dto)
    {
        var result = await _carService.UpdateCarAsync(id, dto);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _carService.DeleteCarAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}