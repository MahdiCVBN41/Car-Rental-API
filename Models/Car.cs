namespace CarRentalAPI.Models;

public class Car
{
    public int CarId { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public decimal DailyRate { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedAt { get; set; }
}