using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2Retake.Entities;

public class Car
{
    [Key]
    public int CarId { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string Brand { get; set; } = null!;
    
    [Column(TypeName = "varchar(100)")]
    public string Model { get; set; } = null!;
    
    public int Year { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal PricePerDay { get; set; }
    
    public int? Mileage { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}