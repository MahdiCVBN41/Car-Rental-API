using AutoMapper;
using CarRentalAPI.DTOs;
using CarRentalAPI.Models;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.Services;

public class RentalService : IRentalService
{
    private readonly IRentalRepository _repository;
    private readonly IMapper _mapper;

    public RentalService(IRentalRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RentalDto>> GetAllRentalsAsync()
    {
        var rentals = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<RentalDto>>(rentals);
    }

    public async Task<RentalDto?> GetRentalByIdAsync(int id)
    {
        var rental = await _repository.GetByIdAsync(id);
        return rental == null ? null : _mapper.Map<RentalDto>(rental);
    }

    public async Task<int> CreateRentalAsync(CreateRentalDto dto)
    {
        var rental = _mapper.Map<Rental>(dto);
        return await _repository.AddAsync(rental);
    }

    public async Task<bool> UpdateRentalAsync(int id, UpdateRentalDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteRentalAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<RentalDto>> GetRentalsByCustomerAsync(int customerId)
    {
        var rentals = await _repository.GetRentalsByCustomerAsync(customerId);
        return _mapper.Map<IEnumerable<RentalDto>>(rentals);
    }

    public async Task<IEnumerable<RentalDto>> GetActiveRentalsAsync()
    {
        var rentals = await _repository.GetActiveRentalsAsync();
        return _mapper.Map<IEnumerable<RentalDto>>(rentals);
    }

    public async Task<RentalDto?> GetRentalWithDetailsAsync(int rentalId)
    {
        var rental = await _repository.GetRentalWithDetailsAsync(rentalId);
        return rental == null ? null : _mapper.Map<RentalDto>(rental);
    }
}