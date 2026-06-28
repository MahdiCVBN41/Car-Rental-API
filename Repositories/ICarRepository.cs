using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
    Task<int> AddAsync(Car car);
    Task<bool> UpdateAsync(Car car);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Car>> GetAvailableCarsAsync();
}