using CarRentalAPI.DTOs;

namespace CarRentalAPI.Services;

public interface IRentalService
{
    Task<IEnumerable<RentalDto>> GetAllRentalsAsync();
    Task<RentalDto?> GetRentalByIdAsync(int id);
    Task<int> CreateRentalAsync(CreateRentalDto dto);
    Task<bool> UpdateRentalAsync(int id, UpdateRentalDto dto);
    Task<bool> DeleteRentalAsync(int id);
    Task<IEnumerable<RentalDto>> GetRentalsByCustomerAsync(int customerId);
    Task<IEnumerable<RentalDto>> GetActiveRentalsAsync();
    Task<RentalDto?> GetRentalWithDetailsAsync(int rentalId);
}