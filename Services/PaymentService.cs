using AutoMapper;
using CarRentalAPI.DTOs;
using CarRentalAPI.Models;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;
    private readonly IMapper _mapper;

    public PaymentService(IPaymentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
    {
        var payments = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PaymentDto>>(payments);
    }

    public async Task<PaymentDto?> GetPaymentByIdAsync(int id)
    {
        var payment = await _repository.GetByIdAsync(id);
        return payment == null ? null : _mapper.Map<PaymentDto>(payment);
    }

    public async Task<int> CreatePaymentAsync(CreatePaymentDto dto)
    {
        var payment = _mapper.Map<Payment>(dto);
        payment.PaymentDate = DateTime.Now;
        return await _repository.AddAsync(payment);
    }

    public async Task<bool> DeletePaymentAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PaymentDto>> GetPaymentsByRentalAsync(int rentalId)
    {
        var payments = await _repository.GetPaymentsByRentalAsync(rentalId);
        return _mapper.Map<IEnumerable<PaymentDto>>(payments);
    }
}