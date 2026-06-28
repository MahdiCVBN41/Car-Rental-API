using CarRentalAPI.DTOs;

namespace CarRentalAPI.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto?> GetCustomerByIdAsync(int id);
    Task<int> CreateCustomerAsync(CreateCustomerDto dto);
    Task<bool> UpdateCustomerAsync(int id, UpdateCustomerDto dto);
    Task<bool> DeleteCustomerAsync(int id);
    Task<CustomerDto?> GetCustomerByEmailAsync(string email);
}