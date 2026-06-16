using Test2Retake.DTOs.Responses;

namespace Test2Retake.Services;

public interface ICarService
{
    Task<ICollection<CarResponseDto>> GetCarsAsync(string? brand);
}