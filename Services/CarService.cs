using Microsoft.EntityFrameworkCore;
using Test2Retake.Data;
using Test2Retake.DTOs.Responses;

namespace Test2Retake.Services;

public class CarService : ICarService
{
    private readonly AppDbContext _dbContext;
    public CarService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<CarResponseDto>> GetCarsAsync(string? brand)
    {
        return await _dbContext.Cars
            .Include(c=>c.Rentals)
                .ThenInclude(r=>r.Customer)
            .Include(c=>c.Rentals)
                .ThenInclude(r=>r.RentalExtras)
                    .ThenInclude(re=>re.Extra)
            .Where(c=>string.IsNullOrEmpty(brand) || c.Brand.StartsWith(brand))
            .Select(c=> new CarResponseDto
            {
                CarId = c.CarId,
                Brand = c.Brand,
                Model = c.Model,
                Year = c.Year,
                PricePerDay = c.PricePerDay,
                Mileage = c.Mileage??null,
                Rentals = c.Rentals.Select(r=> new RentalResponseDto
                {
                    RentalId = r.RentalId,
                    Customer = new CustomerResponseDto
                    {
                        FirstName = r.Customer.FirstName,
                        LastName = r.Customer.LastName,
                        DrivingLicenseNumber = r.Customer.DrivingLicenseNumber,
                        Phone = r.Customer.Phone
                    },
                    RentalDate = r.RentalDate,
                    ReturnDate = r.ReturnDate??null,
                    Status = r.Status,
                    RentalExtras = r.RentalExtras.Select(re=> new RentalExtraResponseDto
                    {
                        Quantity = re.Quantity,
                        AddedAt = re.AddedAt,
                        Extra = new ExtraResponseDto
                        {
                            ExtraId = re.ExtraId,
                            Name = re.Extra.Name,
                            Description = re.Extra.Description,
                            PricePerDay = re.Extra.PricePerDay
                        }
                    }).ToList()
                }).ToList()
            }).ToListAsync();
    }
}