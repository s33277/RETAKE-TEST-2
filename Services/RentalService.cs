using Microsoft.EntityFrameworkCore;
using Test2Retake.Data;
using Test2Retake.DTOs.Requests;
using Test2Retake.Services.Results;

namespace Test2Retake.Services;

public class RentalService : IRentalService
{
    private readonly AppDbContext _dbContext;
    public RentalService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ReturnRentalResult> ReturnRentalAsync(int id, ReturnRentalRequestDto request)
    {
        var rental = await _dbContext.Rentals.FirstOrDefaultAsync(r => r.RentalId == id);
        if (rental == null)
        {
            return ReturnRentalResult.RentalNotFound;
        }

        if (rental.Status == "Returned")
        {
            return ReturnRentalResult.RentalAlreadyReturned;
        }

        if (request.ReturnDate < rental.RentalDate)
        {
            return ReturnRentalResult.InvalidRentalDate;
        }
        
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            rental.Status = "Returned";
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return ReturnRentalResult.Success;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            return ReturnRentalResult.TransactionFailed;
        }
    }
}