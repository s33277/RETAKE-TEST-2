using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2Retake.Entities;

public class Extra
{
    [Key]
    public int ExtraId { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; } = null!;
    
    [Column(TypeName = "varchar(200)")]
    public string Description { get; set; } = null!;
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal PricePerDay { get; set; }
    
    public ICollection<RentalExtra> RentalExtras { get; set; } = new List<RentalExtra>();
}