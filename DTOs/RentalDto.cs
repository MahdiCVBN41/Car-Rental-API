using CarRentalAPI.Models;

namespace CarRentalAPI.DTOs;

public class RentalDto
{
    public int RentalId { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal TotalCost { get; set; }
    public RentalStatus Status { get; set; }
    public CarDto? Car { get; set; }
    public CustomerDto? Customer { get; set; }
}

public class CreateRentalDto
{
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal TotalCost { get; set; }
    public RentalStatus Status { get; set; } = RentalStatus.Active;
}

public class UpdateRentalDto
{
    public DateTime? ReturnDate { get; set; }
    public decimal? TotalCost { get; set; }
    public RentalStatus? Status { get; set; }
}