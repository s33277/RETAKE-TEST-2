using Microsoft.AspNetCore.Mvc;
using Test2Retake.DTOs.Requests;
using Test2Retake.Services;
using Test2Retake.Services.Results;

namespace Test2Retake.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : ControllerBase
{
    
    private readonly IRentalService _rentalService;
    public RentalsController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }
    
    
    [HttpPut("/{id:int}/return")]
    public async Task<IActionResult> UpdatePatient(int id, [FromBody] ReturnRentalRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _rentalService.ReturnRentalAsync(id, request);

        return result switch
        {
            ReturnRentalResult.Success => 
                NoContent(),
            
            ReturnRentalResult.RentalNotFound => 
                NotFound(new { Message = $"Rental with ID {id} was not found." }),
            
            ReturnRentalResult.RentalAlreadyReturned =>
                Conflict(new { Message = $"Rental with ID {id} was already returned." }),
            
            ReturnRentalResult.InvalidRentalDate => 
                BadRequest(new { Message = "The provided date of rental is invalid." }),
            
            _ => 
                StatusCode(500, new { Message = "An internal error occurred." })
        };
    }
}