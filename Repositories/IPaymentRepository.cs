using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetAllAsync();
    Task<Payment?> GetByIdAsync(int id);
    Task<int> AddAsync(Payment payment);
    Task<bool> UpdateAsync(Payment payment);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Payment>> GetPaymentsByRentalAsync(int rentalId);
}