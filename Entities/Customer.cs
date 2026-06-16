using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2Retake.Entities;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; } = null!;
    
    [Column(TypeName = "varchar(100)")]
    public string LastName { get; set; } = null!;
    
    [Column(TypeName = "varchar(20)")]
    public string DrivingLicenseNumber { get; set; } = null!;
    
    [Column(TypeName = "varchar(9)")]
    public string Phone { get; set; } = null!;
    
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}