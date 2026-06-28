using AutoMapper;
using CarRentalAPI.DTOs;
using CarRentalAPI.Models;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _repository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
    {
        var cars = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }

    public async Task<CarDto?> GetCarByIdAsync(int id)
    {
        var car = await _repository.GetByIdAsync(id);
        return car == null ? null : _mapper.Map<CarDto>(car);
    }

    public async Task<int> CreateCarAsync(CreateCarDto dto)
    {
        var car = _mapper.Map<Car>(dto);
        car.IsAvailable = true; 
        return await _repository.AddAsync(car);
    }

    public async Task<bool> UpdateCarAsync(int id, UpdateCarDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteCarAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CarDto>> GetAvailableCarsAsync()
    {
        var cars = await _repository.GetAvailableCarsAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }
}