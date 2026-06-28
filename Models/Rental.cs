namespace CarRentalAPI.Models;

public enum RentalStatus
{
    Active = 0,
    Completed = 1,
    Cancelled = 2
}

public class Rental
{
    public int RentalId { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal TotalCost { get; set; }
    public RentalStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties (not stored in DB, used for joins)
    public Car? Car { get; set; }
    public Customer? Customer { get; set; }
}