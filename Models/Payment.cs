namespace CarRentalAPI.Models;

public enum PaymentMethod
{
    CreditCard = 0,
    DebitCard = 1,
    PayPal = 2,
    Cash = 3
}

public class Payment
{
    public int PaymentId { get; set; }
    public int RentalId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Rental? Rental { get; set; }
}