using CarRentalAPI.DTOs;

namespace CarRentalAPI.Services;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
    Task<PaymentDto?> GetPaymentByIdAsync(int id);
    Task<int> CreatePaymentAsync(CreatePaymentDto dto);
    Task<bool> DeletePaymentAsync(int id);
    Task<IEnumerable<PaymentDto>> GetPaymentsByRentalAsync(int rentalId);
}