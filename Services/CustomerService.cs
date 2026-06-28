using AutoMapper;
using CarRentalAPI.DTOs;
using CarRentalAPI.Models;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        return customer == null ? null : _mapper.Map<CustomerDto>(customer);
    }

    public async Task<int> CreateCustomerAsync(CreateCustomerDto dto)
    {
        var customer = _mapper.Map<Customer>(dto);
        return await _repository.AddAsync(customer);
    }

    public async Task<bool> UpdateCustomerAsync(int id, UpdateCustomerDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<CustomerDto?> GetCustomerByEmailAsync(string email)
    {
        var customer = await _repository.GetByEmailAsync(email);
        return customer == null ? null : _mapper.Map<CustomerDto>(customer);
    }
}