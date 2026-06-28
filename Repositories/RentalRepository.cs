using CarRentalAPI.Data;
using CarRentalAPI.Models;
using Dapper;

namespace CarRentalAPI.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly DapperContext _context;

    public RentalRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Rental>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Rentals";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Rental>(sql);
    }

    public async Task<Rental?> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM Rentals WHERE RentalId = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Rental>(sql, new { Id = id });
    }

    public async Task<int> AddAsync(Rental rental)
    {
        const string sql = @"
            INSERT INTO Rentals (CarId, CustomerId, RentalDate, ReturnDate, TotalCost, Status, CreatedAt)
            VALUES (@CarId, @CustomerId, @RentalDate, @ReturnDate, @TotalCost, @Status, @CreatedAt);
            SELECT CAST(SCOPE_IDENTITY() AS INT)";
        using var connection = _context.CreateConnection();
        rental.CreatedAt = DateTime.Now;
        return await connection.QuerySingleAsync<int>(sql, rental);
    }

    public async Task<bool> UpdateAsync(Rental rental)
    {
        const string sql = @"
            UPDATE Rentals 
            SET CarId = @CarId, CustomerId = @CustomerId, RentalDate = @RentalDate, 
                ReturnDate = @ReturnDate, TotalCost = @TotalCost, Status = @Status
            WHERE RentalId = @RentalId";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, rental);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM Rentals WHERE RentalId = @Id";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }

    public async Task<IEnumerable<Rental>> GetRentalsByCustomerAsync(int customerId)
    {
        const string sql = "SELECT * FROM Rentals WHERE CustomerId = @CustomerId";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Rental>(sql, new { CustomerId = customerId });
    }

    public async Task<IEnumerable<Rental>> GetActiveRentalsAsync()
    {
        const string sql = "SELECT * FROM Rentals WHERE Status = 0"; // Active
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Rental>(sql);
    }

    public async Task<Rental?> GetRentalWithDetailsAsync(int rentalId)
    {
        const string sql = @"
            SELECT r.*, 
                   c.*, 
                   cust.* 
            FROM Rentals r
            INNER JOIN Cars c ON r.CarId = c.CarId
            INNER JOIN Customers cust ON r.CustomerId = cust.CustomerId
            WHERE r.RentalId = @RentalId";
        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<Rental, Car, Customer, Rental>(
            sql,
            (rental, car, customer) =>
            {
                rental.Car = car;
                rental.Customer = customer;
                return rental;
            },
            new { RentalId = rentalId },
            splitOn: "CarId,CustomerId");
        return result.FirstOrDefault();
    }
}