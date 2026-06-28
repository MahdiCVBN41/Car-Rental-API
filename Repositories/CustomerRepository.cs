using CarRentalAPI.Data;
using CarRentalAPI.Models;
using Dapper;

namespace CarRentalAPI.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DapperContext _context;

    public CustomerRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Customers";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Customer>(sql);
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM Customers WHERE CustomerId = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Customer>(sql, new { Id = id });
    }

    public async Task<int> AddAsync(Customer customer)
    {
        const string sql = @"
            INSERT INTO Customers (FirstName, LastName, Email, Phone, Address, DriverLicenseNumber, CreatedAt)
            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DriverLicenseNumber, @CreatedAt);
            SELECT CAST(SCOPE_IDENTITY() AS INT)";
        using var connection = _context.CreateConnection();
        customer.CreatedAt = DateTime.Now;
        return await connection.QuerySingleAsync<int>(sql, customer);
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        const string sql = @"
            UPDATE Customers 
            SET FirstName = @FirstName, LastName = @LastName, Email = @Email, 
                Phone = @Phone, Address = @Address, DriverLicenseNumber = @DriverLicenseNumber
            WHERE CustomerId = @CustomerId";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, customer);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM Customers WHERE CustomerId = @Id";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        const string sql = "SELECT * FROM Customers WHERE Email = @Email";
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Customer>(sql, new { Email = email });
    }
}