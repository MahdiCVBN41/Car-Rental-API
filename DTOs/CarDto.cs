namespace CarRentalAPI.DTOs;

public class CarDto
{
    public int CarId { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public decimal DailyRate { get; set; }
    public bool IsAvailable { get; set; }
}

public class CreateCarDto
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public decimal DailyRate { get; set; }
}

public class UpdateCarDto
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? LicensePlate { get; set; }
    public decimal? DailyRate { get; set; }
    public bool? IsAvailable { get; set; }
}