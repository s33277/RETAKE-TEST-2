using Microsoft.AspNetCore.Mvc;
using Test2Retake.Services;

namespace Test2Retake.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;
    public CarsController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCars([FromQuery] string? brand)
    {
        var result = await _carService.GetCarsAsync(brand);
        return Ok(result);
    }

}