namespace Test2Retake.DTOs.Responses;

public class CarResponseDto
{
    public int CarId { get; set; }
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public int? Mileage { get; set; }
    public ICollection<RentalResponseDto> Rentals { get; set; } = new List<RentalResponseDto>();
}

public class RentalResponseDto
{
    public int RentalId { get; set; }
    public CustomerResponseDto Customer { get; set; } = null!;
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; } = null!;
    public ICollection<RentalExtraResponseDto> RentalExtras { get; set; } = new List<RentalExtraResponseDto>();
}

public class CustomerResponseDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DrivingLicenseNumber { get; set; } = null!;
    public string Phone { get; set; } = null!;
}

public class RentalExtraResponseDto
{
    public int Quantity { get; set; }
    public DateTime AddedAt { get; set; }
    public ExtraResponseDto Extra { get; set; } = null!;
}

public class ExtraResponseDto
{
    public int ExtraId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal PricePerDay { get; set; }
}