using CarRentalAPI.Models;

namespace CarRentalAPI.DTOs;

public class PaymentDto
{
    public int PaymentId { get; set; }
    public int RentalId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public RentalDto? Rental { get; set; }
}

public class CreatePaymentDto
{
    public int RentalId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
}