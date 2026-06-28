using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories;

public interface IRentalRepository
{
    Task<IEnumerable<Rental>> GetAllAsync();
    Task<Rental?> GetByIdAsync(int id);
    Task<int> AddAsync(Rental rental);
    Task<bool> UpdateAsync(Rental rental);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Rental>> GetRentalsByCustomerAsync(int customerId);
    Task<IEnumerable<Rental>> GetActiveRentalsAsync();
    Task<Rental?> GetRentalWithDetailsAsync(int rentalId);
}