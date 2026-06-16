using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2Retake.Entities;

public class Rental
{
    [Key]
    public int RentalId { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
    
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string Status { get; set; } = null!;
    
    public ICollection<RentalExtra> RentalExtras { get; set; } = new List<RentalExtra>();
}