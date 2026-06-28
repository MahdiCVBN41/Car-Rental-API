using CarRentalAPI.DTOs;

namespace CarRentalAPI.Services;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllCarsAsync();
    Task<CarDto?> GetCarByIdAsync(int id);
    Task<int> CreateCarAsync(CreateCarDto dto);
    Task<bool> UpdateCarAsync(int id, UpdateCarDto dto);
    Task<bool> DeleteCarAsync(int id);
    Task<IEnumerable<CarDto>> GetAvailableCarsAsync();
}