using CarRentalAPI.Data;
using CarRentalAPI.Models;
using Dapper;

namespace CarRentalAPI.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly DapperContext _context;

    public PaymentRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Payments";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Payment>(sql);
    }

    public async Task<Payment?> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM Payments WHERE PaymentId = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Payment>(sql, new { Id = id });
    }

    public async Task<int> AddAsync(Payment payment)
    {
        const string sql = @"
            INSERT INTO Payments (RentalId, Amount, PaymentDate, PaymentMethod, TransactionId, CreatedAt)
            VALUES (@RentalId, @Amount, @PaymentDate, @PaymentMethod, @TransactionId, @CreatedAt);
            SELECT CAST(SCOPE_IDENTITY() AS INT)";
        using var connection = _context.CreateConnection();
        payment.CreatedAt = DateTime.Now;
        return await connection.QuerySingleAsync<int>(sql, payment);
    }

    public async Task<bool> UpdateAsync(Payment payment)
    {
        const string sql = @"
            UPDATE Payments 
            SET RentalId = @RentalId, Amount = @Amount, PaymentDate = @PaymentDate, 
                PaymentMethod = @PaymentMethod, TransactionId = @TransactionId
            WHERE PaymentId = @PaymentId";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, payment);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM Payments WHERE PaymentId = @Id";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByRentalAsync(int rentalId)
    {
        const string sql = "SELECT * FROM Payments WHERE RentalId = @RentalId";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Payment>(sql, new { RentalId = rentalId });
    }
}