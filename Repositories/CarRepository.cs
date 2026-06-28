using CarRentalAPI.Data;
using CarRentalAPI.Models;
using Dapper;

namespace CarRentalAPI.Repositories;

public class CarRepository : ICarRepository
{
    private readonly DapperContext _context;

    public CarRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Cars";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Car>(sql);
    }

    public async Task<Car?> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM Cars WHERE CarId = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Car>(sql, new { Id = id });
    }

    public async Task<int> AddAsync(Car car)
    {
        const string sql = @"
            INSERT INTO Cars (Make, Model, Year, LicensePlate, DailyRate, IsAvailable, CreatedAt)
            VALUES (@Make, @Model, @Year, @LicensePlate, @DailyRate, @IsAvailable, @CreatedAt);
            SELECT CAST(SCOPE_IDENTITY() AS INT)";
        using var connection = _context.CreateConnection();
        car.CreatedAt = DateTime.Now;
        return await connection.QuerySingleAsync<int>(sql, car);
    }

    public async Task<bool> UpdateAsync(Car car)
    {
        const string sql = @"
            UPDATE Cars 
            SET Make = @Make, Model = @Model, Year = @Year, 
                LicensePlate = @LicensePlate, DailyRate = @DailyRate, IsAvailable = @IsAvailable
            WHERE CarId = @CarId";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, car);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM Cars WHERE CarId = @Id";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }

    public async Task<IEnumerable<Car>> GetAvailableCarsAsync()
    {
        const string sql = "SELECT * FROM Cars WHERE IsAvailable = 1";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Car>(sql);
    }
}