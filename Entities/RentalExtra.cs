namespace Test2Retake.Entities;

public class RentalExtra
{
    public int RentalId { get; set; }
    public Rental Rental { get; set; } = null!;
    
    public int ExtraId { get; set; }
    public Extra Extra { get; set; } = null!;
    
    public int Quantity { get; set; }
    
    public DateTime AddedAt { get; set; }
}